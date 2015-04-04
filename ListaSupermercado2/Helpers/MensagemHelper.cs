using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaSupermercado2.Helpers
{
    public class MensagemHelper
    {
        public static IHtmlString Mensagem(string mensagem, string tipo)
        {
            var tag = "";
            if (mensagem != null)
            {
                tag = String.Format("<div class='alert alert-{0}'>{1}</div>",
                   tipo, mensagem);
            }

            return new HtmlString(tag);
        }
    }
}