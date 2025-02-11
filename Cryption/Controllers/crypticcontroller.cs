using Microsoft.AspNetCore.Mvc;


using Cryption.services;

namespace Cryption.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class crypticcontroller : ControllerBase
    {
        private const int Shift = 3; 

        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string plainText)
        {
            try
            {
                string encryptedText = crypticservices.Encrypt(plainText, Shift);
                return Ok(new { EncryptedText = encryptedText });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string cipherText)
        {
            try
            {
                string decryptedText = crypticservices.Decrypt(cipherText, Shift);
                return Ok(new { DecryptedText = decryptedText });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

    }
}
