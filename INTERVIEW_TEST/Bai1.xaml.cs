using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Xml;

namespace INTERVIEW_TEST
{
    /// <summary>
    /// Interaction logic for Bai1.xaml
    /// </summary>
    public partial class Bai1 : Window
    {
        private string Path;
        private string Content;
        private TreeViewItem rootNode = new TreeViewItem();
        public Bai1()
        {
            InitializeComponent();
        }
        //Chọn và mở file
        private void SelectFile(object sender, RoutedEventArgs e)
        {
            // Tạo một thread mới và truyền vào phương thức DoWork
            Thread thread = new Thread(GetFile);
            // Bắt đầu thực thi luồng
            thread.Start();
            thread.Join();
            FilePath.Text = Path;
            Tree.Text = Content;
            // Đọc tệp XML
            string xmlFilePath = Path;
            try {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);
                // Tạo nút gốc cho TreeView
                rootNode.Header = xmlDoc.DocumentElement.GetAttribute("text");
                xmlTreeView.Items.Add(rootNode);
                // Gọi hàm để đọc các phần tử con và thêm chúng vào cây
                AddXmlNodes(xmlDoc.DocumentElement, rootNode);
            }
            catch
            {
                MessageBox.Show("File không đúng định dạng XML");
                return;
            }

        }

        private void GetFile()
        {
            // Thực thi tác vụ trong luồng mới
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file";
            openFileDialog.Filter = "XML files (*.xml|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                //Lưu đường dẫn file
                Path = openFileDialog.FileName;
                // Đọc nội dung của file XML
                Content = File.ReadAllText(Path);
            }
        }


        private void AddXmlNodes(XmlNode xmlNode, TreeViewItem treeNode)
        {
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                TreeViewItem childTreeNode = new TreeViewItem();
                childTreeNode.Header = childNode.Attributes["text"]?.Value;

                treeNode.Items.Add(childTreeNode);

                // Đệ quy để thêm các phần tử con của phần tử hiện tại
                AddXmlNodes(childNode, childTreeNode);
            }
        }
    }
}
