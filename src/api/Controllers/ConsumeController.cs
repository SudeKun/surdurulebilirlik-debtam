namespace surdurulebilirlik_app.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Oracle.ManagedDataAccess.Client;
    using surdurulebilirlik_app.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class ConsumeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ConsumeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Consume
        [HttpGet]
        public IActionResult Get()
        {
            var connectionString = _configuration.GetConnectionString("OracleDb");
            var result = new List<Consume>();

            using var connection = new OracleConnection(connectionString);
            connection.Open();

            using var command = new OracleCommand("SELECT Id, SurdurulebilirlikId, \"Number\", \"Change\", SubTypeId FROM Consume WHERE Id IN (SELECT Id FROM DataName WHERE Name = 'Lights' AND Type = 'Consume')", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Consume
                {
                    Id = reader.GetInt32(0),
                    SurdurulebilirlikId = reader.GetInt32(1),
                    Number = reader.GetInt32(2),
                    Change = reader.GetInt32(3),
                    SubTypeId = reader.GetInt32(4)
                });
            }
            return Ok(result);
        }

        // POST: api/Consume
        [HttpPost]
        public IActionResult Post([FromBody] ConsumeCreateDto dto)
        {
            var connectionString = _configuration.GetConnectionString("OracleDb");
            using var connection = new OracleConnection(connectionString);
            connection.Open();

            // 1. Insert into Surdurulebilirlik
            int surId;
            using (var cmd = new OracleCommand("INSERT INTO Surdurulebilirlik (DataNameId) VALUES (:dataNameId) RETURNING Id INTO :id", connection))
            {
                cmd.Parameters.Add(new OracleParameter("dataNameId", dto.DataNameId));
                var idParam = new OracleParameter("id", OracleDbType.Int32, System.Data.ParameterDirection.Output);
                cmd.Parameters.Add(idParam);
                cmd.ExecuteNonQuery();
                surId = Convert.ToInt32(idParam.Value.ToString());
            }

            // 2. Insert into Consume
            using (var cmd = new OracleCommand("INSERT INTO Consume (SurdurulebilirlikId, \"Number\", \"Change\", SubTypeId) VALUES (:sid, :num, :chg, :subid)", connection))
            {
                cmd.Parameters.Add(new OracleParameter("sid", surId));
                cmd.Parameters.Add(new OracleParameter("num", dto.Number));
                cmd.Parameters.Add(new OracleParameter("chg", dto.Change));
                cmd.Parameters.Add(new OracleParameter("subid", dto.SubTypeId));
                cmd.ExecuteNonQuery();
            }

            return Ok(new { message = "Saved successfully" });
        }
    }
}
