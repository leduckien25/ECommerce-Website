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

        public static string GetIdAddress(HttpContext context)
        {
            var ipAddress = context?.Connection?.RemoteIpAddress;

            string clientIp = "127.0.0.1";
            if (ipAddress != null)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    ipAddress = System.Net.Dns.GetHostEntry(ipAddress).AddressList
                        .FirstOrDefault(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                }

            }

            return ipAddress?.ToString() ?? clientIp;
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

        public static string? SaveImage(Product product, IFormFile file)
        {
            if (file == null) return null;

            string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products");
            if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);


            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                string oldPath = Path.Combine(imagesFolder, product.ImageUrl);
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
            if (product.ImageUrl == null) return;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products", product.ImageUrl);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
