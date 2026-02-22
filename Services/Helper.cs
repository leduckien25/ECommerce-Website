using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Services
{
    public static class Helper
    {
        public static T? Get<T>(this ISession session, string key)
        {
            var result = session.GetString(key);

            if (result == null)
                return default;

            return JsonSerializer.Deserialize<T>(result);
        }
        public static void Set<T>(this ISession session, string key, T value)
        {
            var result = JsonSerializer.Serialize<T>(value);

            session.SetString(key, result);
        }
        /// <summary>
        /// Gets the current ASP.NET Identity UserId from claims
        /// </summary>
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier)
                   ?? throw new InvalidOperationException("User ID not found in claims.");
        }
        public static string HmacSHA512(string key, string data)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var dataBytes = Encoding.UTF8.GetBytes(data);

            using var hmac = new HMACSHA512(keyBytes);
            var hashBytes = hmac.ComputeHash(dataBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public static string GetIpAddress(HttpContext context)
        {
            string clientIp = "127.0.0.1";

            if (context is null)
            {
                return clientIp;
            }

            var ipAddress = context.Connection.RemoteIpAddress.ToString();

            if (ipAddress == "::1") ipAddress = "127.0.0.1";
            return ipAddress ?? "127.0.0.1";

        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }
        /// <summary>
        /// Saves the specified image file for the given product and returns the new file name.
        /// </summary>
        /// <remarks>The method creates the necessary directory structure if it does not already exist. If
        /// the product has an existing image, it will be removed before saving the new file.</remarks>
        /// <param name="product">The product for which the image is being saved. If the product already has an associated image, it will be
        /// deleted before saving the new one.</param>
        /// <param name="file">The image file to be saved. Cannot be null; if null, the method returns null.</param>
        /// <returns>The new file name of the saved image, or null if the file parameter is null.</returns>
        public static string? SaveImage(Product product, IFormFile? file)
        {
            if (file == null) return null;

            string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products");
            if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);


            if (!string.IsNullOrEmpty(product.FileName))
            {
                string oldPath = Path.Combine(imagesFolder, product.FileName);
                if (File.Exists(oldPath)) File.Delete(oldPath);
            }

            string ext = Path.GetExtension(file.FileName);
            string newFileName = RandomString(Math.Max(1, 20 - ext.Length)) + ext;

            string path = Path.Combine(imagesFolder, newFileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return newFileName;
        }

        public static void DeleteImage(Product product)
        {
            if (product.FileName == null) return;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products", product.FileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
