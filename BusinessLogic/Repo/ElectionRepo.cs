using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using BusinessLogic;
using BusinessLogic.Model;
using BusinessLogic.Interface;

namespace BusinessLogic.Repo
{
    public class ElectionRepo : ElectionInterface
    {
        NpgsqlConnection con = null;
        NpgsqlCommand cmd = null;
        public ElectionRepo()
        {
            con = ConnectionString.Connection();
            cmd = new NpgsqlCommand();
        }
        public int Add(ElectionModel model)
        {
            string query = "INSERT INTO public.election(e_name,e_village,e_dist,e_postcode) VALUES(@e_name,@e_village,@e_dist,@e_postcode)";
            int i = 0;
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@e_name", model.e_name);
                cmd.Parameters.AddWithValue("@e_village", model.e_village);
                cmd.Parameters.AddWithValue("@e_dist", model.e_dist);
                cmd.Parameters.AddWithValue("@e_postcode", model.e_postcode);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public int delete(int e_id)
        {
            int i = 0;
            string query = "DELETE FROM public.election WHERE e_id=@e_id";
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@e_id", e_id);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public List<ElectionModel> listMember()
        {
            List<ElectionModel> mod = new List<ElectionModel>();
            string query = "SELECT * FROM public.election";
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ElectionModel model = new ElectionModel();
                        model.e_id = Convert.ToInt32(dr["e_id"]);
                        model.e_name = dr["e_name"].ToString();
                        model.e_village = dr["e_village"].ToString();
                        model.e_dist = dr["e_dist"].ToString();
                        model.e_postcode = Convert.ToInt32(dr["e_postcode"]);
                        mod.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return mod;
        }

        public int update(ElectionModel model)
        {
            string query = "UPDATE public.election SET e_name=@e_name,e_village=@e_village,e_dist=@e_dist,e_postcode=@e_postcode where e_id=@e_id";
            int i = 0;
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@e_name", model.e_name);
                cmd.Parameters.AddWithValue("@e_village", model.e_village);
                cmd.Parameters.AddWithValue("@e_dist", model.e_dist);
                cmd.Parameters.AddWithValue("@e_postcode", model.e_postcode);
                cmd.Parameters.AddWithValue("@e_id",model.e_id);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return i;
        }
    }
}
