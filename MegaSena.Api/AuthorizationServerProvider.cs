﻿using MegaSena.Application;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Api
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var user = context.UserName;
                var password = context.Password;

               // var db = new ErpContext();

                /* if(user=="augusto") && (password== "Domain")){ }
                var usuario = db.Usuarios.FirstOrDefault(x => x.Email == user && x.Senha == password);

                if (usuario == null)
                {
                    context.SetError("invalid_grant", "Usuário ou senha inválidos");
                    return;
                } */

                // grava acesso usuário e token
                /* db.Entry(usuario).State = EntityState.Modified;
                usuario.SetDataUltimoAcesso();
                db.SaveChanges(); */


                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                var roles = new List<string>();
                roles.Add("User");


                //identity.AddClaim(new Claim("IdGrupoUsuario", usuario.IdGrupoUsuario.ToString()));
                //identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Email));

                //foreach (var role in roles)
                //{
                //    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                //}

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                /* var props = new AuthenticationProperties(new Dictionary<string, string>()
                       {
                           { "Login", usuario.Login },
                           { "IdClinica", usuario.IdClinica.ToString() },
                           { "IdGrupoUsuario", usuario.IdGrupoUsuario.ToString() }
                });  

               var ticket = new AuthenticationTicket(identity, props); */

               context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", "Falha ao autenticar " + ex.Message);
            }

        }
    }
}