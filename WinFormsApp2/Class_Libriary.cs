using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace WinFormsApp2
{
    public class User_Class
    {
        public int? Id { get; set; }
        public string? login { get; set; }
        public string? password { get; set; }
        public string? created_date { get; set; }
        
        public User_Group_Class? user_group_id { get; set; }
        public User_State_Class? user_state_id { get; set; }
        
        /* public int user_group_id { get; set; }
         public int user_state_id { get; set; }*/
    }

    public class User_Group_Class
    {
        public User_Group_Class() { }
        public User_Group_Class(bool Admin = true)
        {


            if (Admin)
            {
                descripion = "Админ";
                this.code = 777;
            }
            else descripion = "Пользователь";
        }
       
        public int Id { get; set; }
        /// <summary>
        /// 777-admin
        /// </summary>
        public int code { get; set; }

        public string? descripion { get; set; }
    }

    public class User_State_Class
    {
        public User_State_Class() { }   
       public User_State_Class(bool code = true) 
        {
            this.code = code;

            if (this.code) descripion = "Активен";
            else descripion = "Отключен";
        }
       
        public int Id { get; set; }
        public bool code { get; set; }
        
        public string? descripion { get; set; }
    }




    public class ApplicationContext : DbContext
    {
        public DbSet<User_Class> Users { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Bykov_db3;Username=postgres;Password=123555");
        }
    }

}
