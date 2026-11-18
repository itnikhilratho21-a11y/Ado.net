using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class TrainerDB
    {
        public void AllTrainer(out List<Trainer> trainers,out List<Student> students)
        {
            trainers = new List<Trainer>();
            students = new List<Student>();

            String connectionStrinng = "Server=.\\SQLEXPRESS;Initial Catalog=A12;integrated Security=true;";

            SqlConnection con = new SqlConnection(connectionStrinng);
            String quary = "Select * from Student; Select * from Trainer;";
            SqlCommand cmd = new SqlCommand(quary, con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if(ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var ans = ds.Tables[0].Rows[i];
                        Student s = new Student();
                        s.Rollnumber = (int)ans["Rollnumber"];
                        s.Name = ans["Name"].ToString();
                        s.TrainerId = (int)ans["TrainerId"];

                        students.Add(s);
                    }
                }
                
                if (ds.Tables[1]!=null && ds.Tables[1].Rows.Count > 0)
                {
                    for(int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        var ans = ds.Tables[1].Rows[i];
                        Trainer t = new Trainer();
                        t.Id = (int)ans["Id"];
                        t.Name = ans["Name"].ToString();
                        t.City = ans["City"].ToString();
                        t.Experience = (int)ans["Experience"];

                        trainers.Add(t);

                    }
                }
            }

        }
    }
}
