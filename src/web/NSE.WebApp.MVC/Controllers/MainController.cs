using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if(resposta != null && resposta.Erros.Mensagens.Any())
            {
                foreach (var mensagem in resposta.Erros.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);

                }
                return true;
            }
            return false;
        }
    }
}
