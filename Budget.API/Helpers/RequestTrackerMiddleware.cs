using Budget.MODEL;
using Budget.SERVICE;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

//namespace Budget.API.Helpers
//{
//    public class RequestTrackerMiddleware
//    {
//        private readonly RequestDelegate _next;
//        //private readonly UserService _userService;
//        //private readonly IGreeter _greeter;
//        public RequestTrackerMiddleware(
//            RequestDelegate next
//            //UserService userService
//            //IGreeter greeter
//            )
//        {
//            _next = next;
//            //_greeter = greeter;
//            //_userService = userService;
//        }

//        public async Task Invoke(HttpContext context, IUserService _userService)
//        {
//            ////First, get the incoming request
//            //var request = context.Request;

//            ////Continue down the Middleware pipeline, eventually returning to this class
//            //await _next(context);

//            //var idUser = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


//            //if (idUser != null)
//            //{
//            //    User user = await _userService.GetByIdAsync(Convert.ToInt32(idUser));
//            //    if (user != null)
//            //    {
//            //        user.DateLastActive = DateTime.Now;
//            //        //TODO voir les suppresions user account qd update si un user est deja chargé (connexion)
//            //        //_userService.Update(user);
//            //    }

//            //}
//            ////    //Format the response from the server
//            ////    var response = await FormatResponse(context.Response);

//            ////    //TODO: Save log to chosen datastore

//            ////    //Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
//            ////    await responseBody.CopyToAsync(originalBodyStream);
//            ////}
//        }

//        //private async Task<string> FormatRequest(HttpRequest request)
//        //{
//        //    var body = request.Body;

//        //    //This line allows us to set the reader for the request back at the beginning of its stream.
//        //    request.EnableRewind();

//        //    //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
//        //    var buffer = new byte[Convert.ToInt32(request.ContentLength)];

//        //    //...Then we copy the entire request stream into the new buffer.
//        //    await request.Body.ReadAsync(buffer, 0, buffer.Length);

//        //    //We convert the byte[] into a string using UTF8 encoding...
//        //    var bodyAsText = Encoding.UTF8.GetString(buffer);

//        //    //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
//        //    request.Body = body;

//        //    return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
//        //}

//        //private async Task<string> FormatResponse(HttpResponse response)
//        //{
//        //    //We need to read the response stream from the beginning...
//        //    response.Body.Seek(0, SeekOrigin.Begin);

//        //    //...and copy it into a string
//        //    string text = await new StreamReader(response.Body).ReadToEndAsync();

//        //    //We need to reset the reader for the response so that the client can read it.
//        //    response.Body.Seek(0, SeekOrigin.Begin);

//        //    //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
//        //    return $"{response.StatusCode}: {text}";
//        //}
//    }

//}
