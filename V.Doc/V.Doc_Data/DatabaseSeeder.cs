using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;
using V.Doc_Utilities;

namespace V.Doc_Data
{
    public class DatabaseSeeder : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            User user = new User();

            user.FirstName = "System";
            user.LastName = "Admin";
            user.UserName = "Admin";
            user.Email = "Admin@Admin.Com";
            user.Password = "Admin";
            user.Birthdate = DateTime.Now;
            user.Age = 0;
            user.Gender = "Male";
            user.Type = Enum_UserType.Admin.ToString();
            user.ProfilePicture = "~/UploadedFiles/Images/DefaultAdminPic.jpg";
            

            context.Users.Add(user);

           



            context.SaveChanges();

            base.Seed(context);
        }
    }
}
