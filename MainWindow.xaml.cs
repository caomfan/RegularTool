using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegularTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int index = 0;//从第0个字符串开始查找
        public void CXtxt_string()
        {
            string str = txtSearch.Text;//设置需要查找的字符串
            index = txtContent.Text.IndexOf(str, index);//返回str在textBox1中的索引位置
            if (index < 0)//如果没有找不到字符串，则return
            {
                index = 0;
                txtContent.SelectionStart = 0;
                txtContent.SelectionLength = 0;
                MessageBox.Show("已到结尾");
                return;
            }
            txtContent.SelectionStart = index;//设置需要选中字符串的开始位置
            txtContent.SelectionLength = str.Length;//设置需要选中字符串的结束位置
            index++;
            txtContent.Focus();//设置焦点

            //int rows = textBox2.GetFirstVisibleLineIndex();//得到可见文本框中第一个字符的行索引
            int line = txtContent.GetLineIndexFromCharacterIndex(index);//返回指定字符串索引所在的行号
            //Debug.WriteLine(rows + ",," + line);
            int lastline = txtContent.GetLastVisibleLineIndex();
            if (line > lastline)
            {
                txtContent.ScrollToLine(lastline + 1);//滚动到视图中指定行索引
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("查询字符串为空！");
                return;
            }
            CXtxt_string();
        }
    }
}
