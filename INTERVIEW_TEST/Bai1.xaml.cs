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

        private void ViewUI(object sender, RoutedEventArgs e)
        {
            string filePath = FilePath.Text;
            XNode rootNode = new XNode();
            rootNode = rootNode.LoadXmlFileToXNode(filePath);

            if (rootNode != null)
            {
                // Bây giờ bạn có thể sử dụng rootNode để làm việc với dữ liệu XML đã được chuyển đổi
                // Ví dụ: Hiển thị nó trong một TreeView
                TreeView treeView = new TreeView();
                //treeView.Nodes.Add(rootNode);
            }
            ViewXML xmlUI = new ViewXML();
            xmlUI.ShowDialog();

        }

        
    }
}
