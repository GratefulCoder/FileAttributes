using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileAttributeChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
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

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }

        }

        private void SetAttributes(string path)
        {
            // set read-only to false regardless of current setting so that
            // modifications can be made to attributes.
            File.SetAttributes(path, RemoveAttribute(File.GetAttributes(path), FileAttributes.ReadOnly));

            SetDateTimes(path);
            ModifyAttributes(path);
            string newPath = RenameFile(path);
            newPath = ChangeFileExtension(newPath);

            // Commit
            File.Move(path, newPath);

        }

        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        private void SetDateTimes(string path)
        {
            // change path attributes
            File.SetCreationTime(path, this.createdDatePicker.Value);
            File.SetLastWriteTime(path, this.modifiedDatePicker.Value);
            File.SetLastAccessTime(path, this.accessedDatePicker.Value);
        }

        private void ModifyAttributes(string path)
        {
            if (!CheckBox_AdvancedAttributes.Checked)
            {
                // remove all existing attributes
                foreach (FileAttributes attribute in Enum.GetValues(typeof(FileAttributes)))
                {
                    File.SetAttributes(path, RemoveAttribute(File.GetAttributes(path), attribute));
                }
                // set attribute on file to 'Normal'. 
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Normal);
            }
            else
            {
                SetAdvancedAttributes(path);
            }
        }

        private void SetAdvancedAttributes(string path)
        {
            File.SetAttributes(path, checkBox_readOnly.Checked ? File.GetAttributes(path) | FileAttributes.ReadOnly : RemoveAttribute(File.GetAttributes(path), FileAttributes.ReadOnly));
            File.SetAttributes(path, checkBox_hidden.Checked ? File.GetAttributes(path) | FileAttributes.Hidden : RemoveAttribute(File.GetAttributes(path), FileAttributes.Hidden));
            File.SetAttributes(path, checkBox_archive.Checked ? File.GetAttributes(path) | FileAttributes.Archive : RemoveAttribute(File.GetAttributes(path), FileAttributes.Archive));
            File.SetAttributes(path, checkBox_compressed.Checked ? File.GetAttributes(path) | FileAttributes.Compressed : RemoveAttribute(File.GetAttributes(path), FileAttributes.Compressed));
            //File.SetAttributes(path, checkBox_device.Checked ? File.GetAttributes(path) | FileAttributes.Device : RemoveAttribute(File.GetAttributes(path), FileAttributes.Device));
            File.SetAttributes(path, checkBox_directory.Checked ? File.GetAttributes(path) | FileAttributes.Directory : RemoveAttribute(File.GetAttributes(path), FileAttributes.Directory));
            File.SetAttributes(path, checkBox_encrypted.Checked ? File.GetAttributes(path) | FileAttributes.Encrypted : RemoveAttribute(File.GetAttributes(path), FileAttributes.Encrypted));
            File.SetAttributes(path, checkBox_integrityStream.Checked ? File.GetAttributes(path) | FileAttributes.IntegrityStream : RemoveAttribute(File.GetAttributes(path), FileAttributes.IntegrityStream));
            File.SetAttributes(path, checkBox_noScrubData.Checked ? File.GetAttributes(path) | FileAttributes.NoScrubData : RemoveAttribute(File.GetAttributes(path), FileAttributes.NoScrubData));
            File.SetAttributes(path, checkBox_notContentIndexed.Checked ? File.GetAttributes(path) | FileAttributes.NotContentIndexed : RemoveAttribute(File.GetAttributes(path), FileAttributes.NotContentIndexed));
            File.SetAttributes(path, checkBox_offline.Checked ? File.GetAttributes(path) | FileAttributes.Offline : RemoveAttribute(File.GetAttributes(path), FileAttributes.Offline));
            File.SetAttributes(path, checkBox_reparsePoint.Checked ? File.GetAttributes(path) | FileAttributes.ReparsePoint : RemoveAttribute(File.GetAttributes(path), FileAttributes.ReparsePoint));
            File.SetAttributes(path, checkBox_sparseFile.Checked ? File.GetAttributes(path) | FileAttributes.SparseFile : RemoveAttribute(File.GetAttributes(path), FileAttributes.SparseFile));
            File.SetAttributes(path, checkBox_system.Checked ? File.GetAttributes(path) | FileAttributes.System : RemoveAttribute(File.GetAttributes(path), FileAttributes.System));
            File.SetAttributes(path, checkBox_temporary.Checked ? File.GetAttributes(path) | FileAttributes.Temporary : RemoveAttribute(File.GetAttributes(path), FileAttributes.Temporary));

        }

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

