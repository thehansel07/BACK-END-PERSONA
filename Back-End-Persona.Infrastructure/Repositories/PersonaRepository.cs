using Back_End_Persona.Core.Entities;
using Back_End_Persona.Core.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End_Persona.Infrastructure.Data
{
    public class PersonaRepository : BaseRepository<Persona>, IPersonaRepository
    {
        private IConfiguration _configuration;
        public PersonaRepository(PersonaContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;

        }

        public void AddOrUpdatePersona(PersonaViewModel viewModel, string id)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DevConnectionHansel")))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Generico", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = id;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = viewModel.Nombre;
                        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar).Value = viewModel.FechaNacimiento;
                        cmd.Parameters.Add("@ActionType", SqlDbType.VarChar).Value = 1;

                        conn.Open();
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ha ocurrido un error", ex);
            }


        }

        public void DeletePersona(int IdPersona)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DevConnectionHansel")))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Generico", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = IdPersona;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@ActionType", SqlDbType.VarChar).Value = 2;

                        conn.Open();
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ha ocurrido un error", ex);
            }
        }

        //public List<Persona> GetAllPersonas()
        //{
        //    List<Persona> personas = new List<Persona>();
        //    SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DevConnectionHansel"));
        //    SqlCommand command = new SqlCommand("SELECT * FROM PERSONA", conn);
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        Persona obj = new Persona();
        //        obj.IdPersona = int.Parse(dt.Rows[i]["IdPersona"].ToString());
        //        obj.Nombre = dt.Rows[i]["Nombre"].ToString();
        //        obj.FechaNacimiento = DateTime.Parse(dt.Rows[i]["FechaNacimiento"].ToString());
        //        personas.Add(obj);


        //    }

        //    return personas;
        //}


        public List<Persona> GetAllPersonas()
        {
            List<Persona> personas = new List<Persona>();
            try
            {

                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DevConnectionHansel")))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Generico", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@ActionType", SqlDbType.VarChar).Value = 3;

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Persona obj = new Persona();
                            obj.IdPersona = int.Parse(reader["IdPersona"].ToString());
                            obj.Nombre = reader["Nombre"].ToString();
                            obj.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                            personas.Add(obj);

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ha ocurrido un error", ex);
            }


            return personas;
        }

        public Persona GetPersonasById(int IdPersona)
        {
            try
            {
                Persona obj = new Persona();
                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DevConnectionHansel")))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Generico", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = IdPersona;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@ActionType", SqlDbType.VarChar).Value = 4;
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            obj = new Persona
                            {
                                IdPersona = int.Parse(reader["IdPersona"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString())

                            };

                        }

                    }

                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Ha ocurrido un error", ex);
            }
        }

        //NO ES NECESARIO POR LA CREACION DEL PROC GENERICO
        public void UpdatePersonas(Persona persona, int id)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DevConnectionHansel")))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Generico", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = id;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = persona.Nombre;
                        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar).Value = persona.Nombre;
                        cmd.Parameters.Add("@ActionType", SqlDbType.VarChar).Value = 1;
                        conn.Open();
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ha ocurrido un error", ex);
            }
        }
    }
}
