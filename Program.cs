using Microsoft.Extensions.Hosting;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/encrypt", async (HttpContext ctx) => 
{
    string encryptedText = await EncryptText(ctx.Request.Body);
    await ctx.Response.WriteAsync(encryptedText);

});

app.MapPost("/decrypt", async (HttpContext ctx) =>
{
    string decryptedText = await DecryptText(ctx.Request.Body);
    await ctx.Response.WriteAsync(decryptedText);

});

app.Run();
