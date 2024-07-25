using ApiTrabajador.BLL.Services.Contracts;
using ApiTrabajador.Model;
using ApiTrabajador.PL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTrabajador.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        private readonly ITrabajadorService _service;

        public TrabajadorController(ITrabajadorService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var trabajadorSQL = await _service.Listar();

            List<TrabajadorDTO> lista = trabajadorSQL.Select(e => new TrabajadorDTO()
            {
                Idtrabajador = e.Idtrabajador,
                Cargo = new CargoDTO
                {
                    Idcargo = e.CargoNavigation!.Idcargo,
                    Nombre = e.CargoNavigation!.Nombre,
                    Descripcion = e.CargoNavigation!.Descripcion,
                },
                Nombre = e.Nombre,
                Edad = e.Edad,
                Salario = e.Salario
            }).ToList();

            //return StatusCode(StatusCodes.Status200OK, new
            //{
            //    mensaje = "Empleados Listados",
            //    Listado = lista
            //});

            return Ok(lista);

        }

        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener([FromRoute] int id)
        {
            try
            {
                var trabajador = await _service.Obtener(id);

                if (trabajador == null)
                    return NotFound("Trabajador No Encontrado");

                var trabajadorDTO = new TrabajadorDTO()
                {
                    Idtrabajador = trabajador.Idtrabajador,
                    Cargo = new CargoDTO
                    {
                        Idcargo = trabajador.CargoNavigation!.Idcargo,
                        Nombre = trabajador.CargoNavigation!.Nombre,
                        Descripcion = trabajador.CargoNavigation!.Descripcion,
                    },
                    Nombre = trabajador.Nombre,
                    Edad = trabajador.Edad,
                    Salario = trabajador.Salario
                };

                //return (trabajadorDTO == null) ? NotFound("Trabajador No Encontrado") :
                //    StatusCode(StatusCodes.Status200OK, new
                //    {
                //        mensaje = "Trabajador Encontrado",
                //        cargo = trabajadorDTO
                //    });

                return (trabajadorDTO == null) ? NotFound("Trabajador No Encontrado") :
                    Ok(trabajadorDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] TrabajadorDTO trabajadorDTO)
        {
            try
            {
                var trabajador = new Trabajador()
                {
                    Idtrabajador = trabajadorDTO.Idtrabajador,
                    Idcargo = trabajadorDTO.Cargo!.Idcargo,
                    Nombre = trabajadorDTO.Nombre,
                    Edad = trabajadorDTO.Edad,
                    Salario = trabajadorDTO.Salario
                };

                var respuesta = await _service.Registrar(trabajador);

                return (respuesta) ?
                        StatusCode(StatusCodes.Status200OK, new
                        {
                            mensaje = "Trabajador Registrado",
                            Valor = respuesta
                        }) :
                        StatusCode(StatusCodes.Status500InternalServerError, new
                        {
                            mensaje = "Error al Registrar Trabajador",
                            Valor = respuesta
                        });
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar([FromRoute] int id, [FromBody] TrabajadorDTO trabajadorDTO)
        {
            if (id != trabajadorDTO.Idtrabajador)
                return BadRequest("Error de coincidencia");
            try
            {
                var trabajador = new Trabajador()
                {
                    Idtrabajador = trabajadorDTO.Idtrabajador,
                    Idcargo = trabajadorDTO.Cargo!.Idcargo,
                    Nombre = trabajadorDTO.Nombre,
                    Edad = trabajadorDTO.Edad,
                    Salario = trabajadorDTO.Salario
                };

                var respuesta = await _service.Editar(trabajador, id);

                return (respuesta) ?
                        StatusCode(StatusCodes.Status200OK, new
                        {
                            mensaje = "Trabajador Editado",
                            Valor = respuesta
                        }) :
                        StatusCode(StatusCodes.Status500InternalServerError, new
                        {
                            mensaje = "Error al Editar Trabajador",
                            Valor = respuesta
                        });
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            try
            {
                var respuesta = await _service.Eliminar(id);

                return (respuesta) ?
                        StatusCode(StatusCodes.Status200OK, new
                        {
                            mensaje = "Trabajador Eliminado",
                            Valor = respuesta
                        }) :
                        StatusCode(StatusCodes.Status500InternalServerError, new
                        {
                            mensaje = "Error al Eliminar Trabajador",
                            Valor = respuesta
                        });
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

    }
}
