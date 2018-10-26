using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Logic;
using WebApplication1.Security;

namespace WebApplication1.Controllers
{
    
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private LoginLogic loginLogic = new LoginLogic();

        [HttpGet]
        [AllowAnonymous]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }



        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {

            if (login == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
            ResponseLoginObject loginObject = loginLogic.logValidation(login);
            if (loginObject.status)
            {
                var rolename = loginObject.role;
                var token = TokenGenerator.GenerateTokenJwt(Convert.ToString(login.id_employee), rolename);
                LoginResponse response = new LoginResponse();
                response.role = rolename;
                response.token = token;
                return Ok(response);
            }
            else
            {
                // Unauthorized access 
                return Unauthorized();
            }
        }

        [Route("register")]
        [Authorize(Roles = "Administrador")]
        public IHttpActionResult Register(LoginRequest login)
        {

            if (login == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            EmployeeLogic employeeLogic = new EmployeeLogic();
            if (!employeeLogic.existEmployee(login.id_employee))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return NotFound();
            }
            if (loginLogic.register(login))
            {
                //petición correcta y se ha creado un nuevo recurso code 201
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();
            }
        }

        [Route("unregister")]
        [Authorize(Roles = "Administrador")]
        public IHttpActionResult UnRegister(int login)
        {
            if (!loginLogic.existAccount(login))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (loginLogic.revokeRegister(login))
            {
                //Se completó la solicitud con exito code 200 ok
                return Ok();
            }
            else
            {
                //No se completó la solicitud por un error interno code 500
                return InternalServerError();
            }
        }

    }
}
