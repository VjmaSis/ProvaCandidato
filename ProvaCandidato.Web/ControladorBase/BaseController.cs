using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaCandidato.ControladorBase
{
    public class BaseController<T> : Controller where T : class
    {
        public BaseController()
        {

        }
    }
}