using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileAttributeChanger
{
    public partial class Form1 : Form
    {
        private int filesProcessed;
        private int directoriesProcessed;

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        /// <summary>
        /// Processes all files and directories dropped onto the form.
        /// </summary>
        /// <remarks>
        /// Directories are processed recursively and a summary is displayed when processing completes.
        /// </remarks>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The drag event arguments containing the dropped paths.</param>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            this.filesProcessed = 0;
            this.directoriesProcessed = 0;

            string[] pathArray = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in pathArray)
            {
                try
                {
                    SetAttributes(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("failure: " + ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString());
                    throw;
                }
            }

            MessageBox.Show(
                "Complete." + Environment.NewLine + Environment.NewLine +
                "Files processed: " + this.filesProcessed + Environment.NewLine +
                "Directories processed: " + this.directoriesProcessed);
        }

        /// <summary>
        /// Sets the drag effect when files or directories are dragged onto the form.
        /// </summary>
        /// <remarks>
        /// File system items are accepted using the copy drag effect.
        /// </remarks>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The drag event arguments.</param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// Applies the selected changes to a file or directory.
        /// </summary>
        /// <remarks>
        /// Directories are processed recursively. Files and subdirectories are processed before
        /// the containing directory so the directory's selected timestamps are applied last.
        /// Reparse points are not recursively followed.
        /// </remarks>
        /// <param name="path">The file or directory path to process.</param>
        private void SetAttributes(string path)
        {
            bool isDirectory = Directory.Exists(path);

            // set read-only to false regardless of current setting so that
            // modifications can be made to attributes.
            if (isDirectory)
            {
                DirectoryInfo di = new DirectoryInfo(path);
                di.Attributes = RemoveAttribute(di.Attributes, System.IO.FileAttributes.ReadOnly);

                // Do not recursively follow junctions, symbolic links, or other reparse points.
                bool isReparsePoint = (di.Attributes & System.IO.FileAttributes.ReparsePoint) != 0;

                if (!isReparsePoint)
                {
                    string[] files = Directory.GetFiles(path);
                    foreach (string file in files)
                    {
                        SetAttributes(file);
                    }

                    string[] directories = Directory.GetDirectories(path);
                    foreach (string directory in directories)
                    {
                        SetAttributes(directory);
                    }
                }

                SetDateTimesDirectory(path);
                ModifyAttributesDirectory(path);

                this.directoriesProcessed++;

                // Intentionally do NOT rename / change extension / move directories.
                return;
            }

            File.SetAttributes(path, RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.ReadOnly));

            SetDateTimes(path);
            ModifyAttributes(path);
            string newPath = RenameFile(path);
            newPath = ChangeFileExtension(newPath);

            // Commit
            File.Move(path, newPath);

            this.filesProcessed++;
        }

        /// <summary>
        /// Removes a file system attribute from an existing set of attributes.
        /// </summary>
        /// <remarks>
        /// Uses a bitwise operation to remove only the specified attribute.
        /// </remarks>
        /// <param name="attributes">The current file system attributes.</param>
        /// <param name="attributesToRemove">The attribute or attributes to remove.</param>
        private static System.IO.FileAttributes RemoveAttribute(System.IO.FileAttributes attributes, System.IO.FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        /// <summary>
        /// Sets the selected timestamps on a file.
        /// </summary>
        /// <remarks>
        /// Creation, last write, and last access times are taken from the form controls.
        /// </remarks>
        /// <param name="path">The file path to modify.</param>
        private void SetDateTimes(string path)
        {
            // change path attributes
            File.SetCreationTime(path, this.createdDatePicker.Value);
            File.SetLastWriteTime(path, this.modifiedDatePicker.Value);
            File.SetLastAccessTime(path, this.accessedDatePicker.Value);
        }

        /// <summary>
        /// Sets the selected timestamps on a directory.
        /// </summary>
        /// <remarks>
        /// Creation, last write, and last access times are taken from the form controls.
        /// </remarks>
        /// <param name="path">The directory path to modify.</param>
        private void SetDateTimesDirectory(string path)
        {
            Directory.SetCreationTime(path, this.createdDatePicker.Value);
            Directory.SetLastWriteTime(path, this.modifiedDatePicker.Value);
            Directory.SetLastAccessTime(path, this.accessedDatePicker.Value);
        }

        /// <summary>
        /// Applies the selected file attributes to a file.
        /// </summary>
        /// <remarks>
        /// Existing attributes are cleared when advanced attributes are disabled.
        /// </remarks>
        /// <param name="path">The file path to modify.</param>
        private void ModifyAttributes(string path)
        {
            if (!CheckBox_AdvancedAttributes.Checked)
            {
                // remove all existing attributes
                foreach (System.IO.FileAttributes attribute in Enum.GetValues(typeof(System.IO.FileAttributes)))
                {
                    File.SetAttributes(path, RemoveAttribute(File.GetAttributes(path), attribute));
                }

                // set attribute on file to 'Normal'. 
                File.SetAttributes(path, File.GetAttributes(path) | System.IO.FileAttributes.Normal);
            }
            else
            {
                SetAdvancedAttributes(path);
            }
        }

        /// <summary>
        /// Applies the selected file attributes to a directory.
        /// </summary>
        /// <remarks>
        /// Existing attributes are cleared when advanced attributes are disabled.
        /// </remarks>
        /// <param name="path">The directory path to modify.</param>
        private void ModifyAttributesDirectory(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            if (!CheckBox_AdvancedAttributes.Checked)
            {
                // remove all existing attributes
                foreach (System.IO.FileAttributes attribute in Enum.GetValues(typeof(System.IO.FileAttributes)))
                {
                    di.Attributes = RemoveAttribute(di.Attributes, attribute);
                }

                // set attribute on directory to 'Normal'. 
                di.Attributes = di.Attributes | System.IO.FileAttributes.Normal;
            }
            else
            {
                SetAdvancedAttributesDirectory(di);
            }
        }

        /// <summary>
        /// Applies the advanced attribute selections to a file.
        /// </summary>
        /// <remarks>
        /// Each supported attribute is added or removed based on its corresponding checkbox.
        /// </remarks>
        /// <param name="path">The file path to modify.</param>
        private void SetAdvancedAttributes(string path)
        {
            File.SetAttributes(path, checkBox_readOnly.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.ReadOnly : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.ReadOnly));
            File.SetAttributes(path, checkBox_hidden.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.Hidden : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.Hidden));
            File.SetAttributes(path, checkBox_archive.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.Archive : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.Archive));
            File.SetAttributes(path, checkBox_compressed.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.Compressed : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.Compressed));
            //File.SetAttributes(path, checkBox_device.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.Device : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.Device));
            File.SetAttributes(path, checkBox_directory.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.Directory : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.Directory));
            File.SetAttributes(path, checkBox_encrypted.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.Encrypted : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.Encrypted));
            File.SetAttributes(path, checkBox_integrityStream.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.IntegrityStream : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.IntegrityStream));
            File.SetAttributes(path, checkBox_noScrubData.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.NoScrubData : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.NoScrubData));
            File.SetAttributes(path, checkBox_notContentIndexed.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.NotContentIndexed : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.NotContentIndexed));
            File.SetAttributes(path, checkBox_offline.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.Offline : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.Offline));
            File.SetAttributes(path, checkBox_reparsePoint.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.ReparsePoint : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.ReparsePoint));
            File.SetAttributes(path, checkBox_sparseFile.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.SparseFile : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.SparseFile));
            File.SetAttributes(path, checkBox_system.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.System : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.System));
            File.SetAttributes(path, checkBox_temporary.Checked ? File.GetAttributes(path) | System.IO.FileAttributes.Temporary : RemoveAttribute(File.GetAttributes(path), System.IO.FileAttributes.Temporary));
        }

        /// <summary>
        /// Applies the advanced attribute selections to a directory.
        /// </summary>
        /// <remarks>
        /// Each supported attribute is added or removed based on its corresponding checkbox.
        /// </remarks>
        /// <param name="di">The directory information object to modify.</param>
        private void SetAdvancedAttributesDirectory(DirectoryInfo di)
        {
            di.Attributes = checkBox_readOnly.Checked ? di.Attributes | System.IO.FileAttributes.ReadOnly : RemoveAttribute(di.Attributes, System.IO.FileAttributes.ReadOnly);
            di.Attributes = checkBox_hidden.Checked ? di.Attributes | System.IO.FileAttributes.Hidden : RemoveAttribute(di.Attributes, System.IO.FileAttributes.Hidden);
            di.Attributes = checkBox_archive.Checked ? di.Attributes | System.IO.FileAttributes.Archive : RemoveAttribute(di.Attributes, System.IO.FileAttributes.Archive);
            di.Attributes = checkBox_compressed.Checked ? di.Attributes | System.IO.FileAttributes.Compressed : RemoveAttribute(di.Attributes, System.IO.FileAttributes.Compressed);
            //di.Attributes = checkBox_device.Checked ? di.Attributes | System.IO.FileAttributes.Device : RemoveAttribute(di.Attributes, System.IO.FileAttributes.Device);
            di.Attributes = checkBox_directory.Checked ? di.Attributes | System.IO.FileAttributes.Directory : RemoveAttribute(di.Attributes, System.IO.FileAttributes.Directory);
            di.Attributes = checkBox_encrypted.Checked ? di.Attributes | System.IO.FileAttributes.Encrypted : RemoveAttribute(di.Attributes, System.IO.FileAttributes.Encrypted);
            di.Attributes = checkBox_integrityStream.Checked ? di.Attributes | System.IO.FileAttributes.IntegrityStream : RemoveAttribute(di.Attributes, System.IO.FileAttributes.IntegrityStream);
            di.Attributes = checkBox_noScrubData.Checked ? di.Attributes | System.IO.FileAttributes.NoScrubData : RemoveAttribute(di.Attributes, System.IO.FileAttributes.NoScrubData);
            di.Attributes = checkBox_notContentIndexed.Checked ? di.Attributes | System.IO.FileAttributes.NotContentIndexed : RemoveAttribute(di.Attributes, System.IO.FileAttributes.NotContentIndexed);
            di.Attributes = checkBox_offline.Checked ? di.Attributes | System.IO.FileAttributes.Offline : RemoveAttribute(di.Attributes, System.IO.FileAttributes.Offline);
            di.Attributes = checkBox_reparsePoint.Checked ? di.Attributes | System.IO.FileAttributes.ReparsePoint : RemoveAttribute(di.Attributes, System.IO.FileAttributes.ReparsePoint);
            di.Attributes = checkBox_sparseFile.Checked ? di.Attributes | System.IO.FileAttributes.SparseFile : RemoveAttribute(di.Attributes, System.IO.FileAttributes.SparseFile);
            di.Attributes = checkBox_system.Checked ? di.Attributes | System.IO.FileAttributes.System : RemoveAttribute(di.Attributes, System.IO.FileAttributes.System);
            di.Attributes = checkBox_temporary.Checked ? di.Attributes | System.IO.FileAttributes.Temporary : RemoveAttribute(di.Attributes, System.IO.FileAttributes.Temporary);
        }

        /// <summary>
        /// Renames a file according to the selected rename options.
        /// </summary>
        /// <remarks>
        /// Supports random names, GUID names, and user-provided rename patterns.
        /// </remarks>
        /// <param name="path">The original file path.</param>
        private string RenameFile(string path)
        {
            if (groupBox_rename.Enabled)
            {
                string originalPath = path;
                string fileNameOnly = Path.GetFileNameWithoutExtension(path);
                string extension = Path.GetExtension(ChangeFileExtension(path));
                string dir = Path.GetDirectoryName(path);

                // Rename file with Random file name
                if (checkBox_RenameRandom.Checked)
                {
                    string randomFilename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                    path = Path.Combine(dir, randomFilename + extension);
                }

                // Rename file with GUID file name
                if (checkBox_GUID.Checked)
                {
                    path = Path.Combine(dir, Guid.NewGuid().ToString() + extension);
                }

                // Rename with user provided value
                if (textBox_RenamePattern.Enabled)
                {
                    int count = 1;
                    fileNameOnly = textBox_RenamePattern.Text;

                    if (!fileNameOnly.Any(x => Path.GetInvalidFileNameChars().Contains(x)))
                    {
                        while (File.Exists(path))
                        {
                            string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                            path = Path.Combine(dir, tempFileName + extension);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You've used an invalid character in your filename.");
                        throw new FormatException();
                    }
                }
            }

            return path;
        }

        /// <summary>
        /// Changes the extension of a file according to the selected extension option.
        /// </summary>
        /// <remarks>
        /// The extension is validated against invalid file name characters before being applied.
        /// </remarks>
        /// <param name="path">The file path to modify.</param>
        private string ChangeFileExtension(string path)
        {
            if (checkBox_fileExtension.Checked)
            {
                if (!textBox_FileExtChange.Text.Any(x => Path.GetInvalidFileNameChars().Contains(x)))
                {
                    // change extension
                    path = Path.ChangeExtension(path, textBox_FileExtChange.Text);
                }
                else
                {
                    MessageBox.Show("You've used an invalid character in your extension.");
                    throw new FormatException();
                }
            }

            return path;
        }

        /// <summary>
        /// Enables or disables the advanced attribute controls.
        /// </summary>
        /// <remarks>
        /// The attribute group is enabled when advanced attributes are selected.
        /// </remarks>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CheckBox_AdvancedAttributes_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AdvancedAttributes.Checked)
            {
                groupBox_attributes.Enabled = true;
            }
            else
            {
                groupBox_attributes.Enabled = false;
            }
        }

        /// <summary>
        /// Updates rename controls when random file naming is selected.
        /// </summary>
        /// <remarks>
        /// Random naming disables the rename pattern and GUID options.
        /// </remarks>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CheckBox_Random_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_RenameRandom.Checked)
            {
                textBox_RenamePattern.Enabled = false;
                checkBox_GUID.Enabled = false;
            }
            else
            {
                textBox_RenamePattern.Enabled = true;
                checkBox_GUID.Enabled = true;
            }
        }

        /// <summary>
        /// Updates rename controls when GUID file naming is selected.
        /// </summary>
        /// <remarks>
        /// GUID naming disables the rename pattern and random naming options.
        /// </remarks>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CheckBox_GUID_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_GUID.Checked)
            {
                textBox_RenamePattern.Enabled = false;
                checkBox_RenameRandom.Enabled = false;
            }
            else
            {
                textBox_RenamePattern.Enabled = true;
                checkBox_RenameRandom.Enabled = true;
            }
        }

        /// <summary>
        /// Enables or disables the date and time controls.
        /// </summary>
        /// <remarks>
        /// The date and time group follows the state of the date/time checkbox.
        /// </remarks>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CheckBox_dateTimes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_dateTimes.Checked)
            {
                groupBox_dateTimes.Enabled = true;
            }
            else
            {
                groupBox_dateTimes.Enabled = false;
            }
        }

        /// <summary>
        /// Enables or disables the file rename controls.
        /// </summary>
        /// <remarks>
        /// The rename group follows the state of the rename checkbox.
        /// </remarks>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void checkBox_rename_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_rename.Checked)
            {
                groupBox_rename.Enabled = true;
            }
            else
            {
                groupBox_rename.Enabled = false;
            }
        }

        /// <summary>
        /// Enables or disables the file extension controls.
        /// </summary>
        /// <remarks>
        /// The file extension group follows the state of the extension checkbox.
        /// </remarks>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void checkBox_fileExtension_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_fileExtension.Checked)
            {
                groupBox_fileExtension.Enabled = true;
            }
            else
            {
                groupBox_fileExtension.Enabled = false;
            }
        }
    }
}