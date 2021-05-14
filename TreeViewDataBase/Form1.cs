using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewDataBase
{
    public partial class Form1 : Form
    {
        private const string connectionString = @"Data Source=ZHEREBEC;Initial Catalog=AdwiserLogDataBase;Integrated Security=True";        // Подключение к БД

        public enum ActionType
        {
            Edit, Create
        }

        public Form1()
        {
            InitializeComponent();
            LoadTree();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private TreeNode CreateTreeNode(string name, string tag, string text)
        {
            TreeNode n = new TreeNode(text);
            n.Name = name;
            n.Tag = tag;
            return n;
        }

        private void LoadTree()
        {
            treeView.Nodes.Clear();
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = connectionString;
                cnn.Open();
                var command = new SqlCommand("select * from Direction", cnn);
                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TreeNode n = CreateTreeNode("Direction", dr["DirectionID"].ToString(), $"{dr["DirectionName"]}");
                        treeView.Nodes.Add(n);
                        LoadCourses(int.Parse(dr["DirectionID"].ToString()), n);
                    }
                }
            }
        }

        private void LoadCourses(int directionID, TreeNode parent)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = connectionString;
                cnn.Open();
                var command = new SqlCommand("select Course.CourseID, CourseNames.NameOfCourse, CourseNames.LevelOfCourse from Course inner join CourseNames on Course.CourseNameID = CourseNames.CourseNameID where DirectionID = @directionID", cnn);
                command.Parameters.AddWithValue("@directionID", directionID);
                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string newTxt = dr["NameOfCourse"] + " - " + dr["LevelOfCourse"];
                        TreeNode n = CreateTreeNode("Course", dr["CourseID"].ToString(), newTxt);
                        parent.Nodes.Add(n);
                        LoadGroups(int.Parse(dr["CourseID"].ToString()), n);
                    }
                }
            }
        }

        private void LoadGroups(int courseID, TreeNode parent)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = connectionString;
                cnn.Open();
                var command = new SqlCommand("select * from Groups where CourseID=@courseID", cnn);
                command.Parameters.AddWithValue("@courseID", courseID);
                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TreeNode n = CreateTreeNode("Groups", dr["GroupID"].ToString(), $"{dr["NumberOfGroup"]}");
                        parent.Nodes.Add(n);
                        LoadStudents(int.Parse(dr["GroupID"].ToString()), n);
                    }
                }
            }
        }

        private void LoadStudents(int groupID, TreeNode parent)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = connectionString;
                cnn.Open();
                var command = new SqlCommand("Select Students.StudentID, Students.StudentLastName, Students.StudentFirstName, Students.StudentMiddleName from Students inner join Groups on Students.GroupID = Groups.GroupID where Groups.GroupID = @groupID", cnn);
                command.Parameters.AddWithValue("@groupID", groupID);
                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string newTxt = dr["StudentLastName"] + " " + dr["StudentFirstName"] + " " + dr["StudentMiddleName"]; 
                        parent.Nodes.Add(CreateTreeNode("Students", dr["StudentID"].ToString(), newTxt));
                    }
                }
            }
        }

        private void обновитьДанныеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadTree();
        }

        private void удалитьДанныеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null) return;

            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = connectionString;
                cnn.Open();
                SqlCommand command = new SqlCommand();
                if (treeView.SelectedNode.Name == "Direction")
                {
                    command = new SqlCommand($"delete from {treeView.SelectedNode.Name} where DirectionID=@id", cnn);
                }
                else if (treeView.SelectedNode.Name == "Course")
                {
                    command = new SqlCommand($"delete from {treeView.SelectedNode.Name} where CourseID=@id", cnn);
                }
                else if (treeView.SelectedNode.Name == "Groups")
                {
                    command = new SqlCommand($"delete from {treeView.SelectedNode.Name} where GroupID=@id", cnn);
                }
                else if (treeView.SelectedNode.Name == "Students")
                {
                    command = new SqlCommand($"delete from {treeView.SelectedNode.Name} where StudentID=@id", cnn);
                }

                command.Parameters.AddWithValue("@id", int.Parse(treeView.SelectedNode.Tag.ToString()));
                command.ExecuteNonQuery();
                treeView.SelectedNode.Remove();
            }
        }

        private void EditDataBase(string command, ActionType actionType)
        {
            if (treeView.SelectedNode == null) return;

            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = connectionString;
                cnn.Open();
                var adapter = new SqlDataAdapter(command, cnn);
                var cb = new SqlCommandBuilder(adapter);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                var eaForm = new EditAddForm(dataSet, adapter, actionType);
                eaForm.ShowDialog();
                LoadTree();
            }
        }

        private void изменитьДанныеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null) return;
            if (treeView.SelectedNode.Name == "Direction")
            {
                EditDataBase($"select * from {treeView.SelectedNode.Name} where DirectionID={int.Parse(treeView.SelectedNode.Tag.ToString())}", ActionType.Edit);
            }
            else if (treeView.SelectedNode.Name == "Course")
            {
                EditDataBase($"select * from {treeView.SelectedNode.Name} where CourseID={int.Parse(treeView.SelectedNode.Tag.ToString())}", ActionType.Edit);
            }
            else if (treeView.SelectedNode.Name == "Groups")
            {
                EditDataBase($"select * from {treeView.SelectedNode.Name} where GroupID={int.Parse(treeView.SelectedNode.Tag.ToString())}", ActionType.Edit);
            }
            else if (treeView.SelectedNode.Name == "Students")
            {
                EditDataBase($"select * from {treeView.SelectedNode.Name} where StudentID={int.Parse(treeView.SelectedNode.Tag.ToString())}", ActionType.Edit);
            }
        }

        private void добавитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null) return;
            EditDataBase($"select * from {treeView.SelectedNode.Name}", ActionType.Create);
        }
    }
}
