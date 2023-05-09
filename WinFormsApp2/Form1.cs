using Microsoft.VisualBasic.ApplicationServices;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        List<User_Class> users;

        private void button1_Click(object sender, EventArgs e)
        {
            //добавляем нового пользователя

            if (textBox1.Text != "")
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    User_State_Class user_state = new User_State_Class(true);
                    User_Group_Class User_Group = new User_Group_Class(checkBox1.Checked);



                    User_Class user1 = new User_Class { login = textBox1.Text, password = textBox2.Text, created_date = DateTime.Now.ToShortDateString(), user_state_id = user_state, user_group_id= User_Group };

                    // добавляем их в бд
                    db.Users.Add(user1);
                    db.SaveChanges();
                }
            }

            UpdateAllUsers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateAllUsers();
        }

        private void UpdateAllUsers()
        {
            richTextBox1.Text = "";

            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим 
                users = db.Users.ToList();

                foreach (User_Class u in users)
                {
                    richTextBox1.AppendText(u.login + " " + u.password + " " + u.created_date + /*" " + u.user_group_id.descripion + " " + u.user_state_id.descripion +*/ "\n");
                }
            }
        }

        public void CreateDB()
        {
            //создаем БД 
            using (ApplicationContext db = new ApplicationContext())
            {
                db.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


    }
}