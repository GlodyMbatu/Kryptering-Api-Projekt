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

async Task<string> EncryptText(Stream requestBody)
{
    // request body

    using var reader = new StreamReader(requestBody);
    string text = await reader.ReadToEndAsync();

    // encrypt logic2

    StringBuilder encryptedText = new StringBuilder();
    foreach (char c in text)
    {
        encryptedText.Append((char)(c+3));
    }

    return encryptedText.ToString();

}

async Task<string> DecryptText(Stream requestBody)
{
    // request body_decrypt

    using var reader = new StreamReader(requestBody);
    string text = await reader.ReadToEndAsync();

    // decrypt logic2

    StringBuilder decryptedText = new StringBuilder();
    foreach (char c in text)
    {
        decryptedText.Append((char)(c-3));
    }

return decryptedText.ToString();
}