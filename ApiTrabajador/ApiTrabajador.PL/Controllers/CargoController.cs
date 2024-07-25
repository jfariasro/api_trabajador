using ApiTrabajador.BLL.Services.Contracts;
using ApiTrabajador.Model;
using ApiTrabajador.PL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTrabajador.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _service;

        public CargoController(ICargoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var cargoSQL = await _service.Listar();

            List<CargoDTO> lista = cargoSQL.Select(c => new CargoDTO()
            {
                Idcargo = c.Idcargo,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion
            }).ToList();

            //return StatusCode(StatusCodes.Status200OK, new
            //{
            //    mensaje = "Cargos Listados",
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
                var cargo = await _service.Obtener(id);

                if (cargo == null)
                    return NotFound("Cargo No Encontrado");

                var cargoDTO = new CargoDTO()
                {
                    Idcargo = cargo.Idcargo,
                    Nombre = cargo.Nombre,
                    Descripcion = cargo.Descripcion
                };

                //return (cargoDTO == null) ? NotFound("Cargo No Encontrado") :
                //    StatusCode(StatusCodes.Status200OK, new
                //    {
                //        mensaje = "Cargo Encontrado",
                //        cargo = cargoDTO
                //    });

                return (cargoDTO == null) ? NotFound("Cargo No Encontrado") :
                    Ok(cargoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] CargoDTO cargoDTO)
        {
            try
            {
                Cargo cargo = new Cargo()
                {
                    Nombre = cargoDTO.Nombre,
                    Descripcion = cargoDTO.Descripcion
                };

                var respuesta = await _service.Registrar(cargo);

                return (respuesta) ?
                        StatusCode(StatusCodes.Status200OK, new
                        {
                            mensaje = "Cargo Registrado",
                            Valor = respuesta
                        }) :
                        StatusCode(StatusCodes.Status500InternalServerError, new
                        {
                            mensaje = "Error al Registrar Cargo",
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
        public async Task<IActionResult> Editar([FromRoute] int id, [FromBody] CargoDTO cargoDTO)
        {
            if(id != cargoDTO.Idcargo)
                return BadRequest("Error de coincidencia");
            try
            {
                Cargo cargo = new Cargo()
                {
                    Idcargo = cargoDTO.Idcargo,
                    Nombre = cargoDTO.Nombre,
                    Descripcion = cargoDTO.Descripcion,
                    Fechamodificacion = DateTime.Now
                };

                var respuesta = await _service.Editar(cargo, id);

                return (respuesta) ?
                        StatusCode(StatusCodes.Status200OK, new
                        {
                            mensaje = "Cargo Editado",
                            Valor = respuesta
                        }) :
                        StatusCode(StatusCodes.Status500InternalServerError, new
                        {
                            mensaje = "Error al Editar Cargo",
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
                            mensaje = "Cargo Eliminado",
                            Valor = respuesta
                        }) :
                        StatusCode(StatusCodes.Status500InternalServerError, new
                        {
                            mensaje = "Error al Eliminar Cargo",
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
