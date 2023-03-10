using Discount.API.Entities;
using Dapper;
using Npgsql;

namespace Discount.API.Repositories
{
    public class DiscountRepository: IDiscountRepository
    {
        
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Coupon> GetCoupon(string ingredientName)
        {
            using var con = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var res =await con.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM COUPON WHERE \"Ingredientname\"=@P", new { P = ingredientName });
            if(res==null)
                return new Coupon();
            return res;
        }
        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var con = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await con.ExecuteAsync("INSERT INTO coupon (\"Ingredientname\", Description, Amount) VALUES (@Ingredientname, @Description, @Amount)",
                new { Ingredientname = coupon.Ingredientname , Description = coupon.Description , Amount = coupon.Amount });

            return affected==0? false:true;
        }
        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var con = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await con.ExecuteAsync("UPDATE coupon SET \"Ingredientname\"=@Ingredientname, Description=@Description, Amount= @Amount" +
                " WHERE Id=@Id",
                new { Ingredientname = coupon.Ingredientname, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

            return affected == 0 ? false : true;
        }

        public async Task<bool> DeleteDiscount(string ingredientName)
        {
            using var con = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await con.ExecuteAsync("DELETE FROM coupon  WHERE \"Ingredientname\"=@Ingredientname",
                new { Ingredientname = ingredientName});

            return affected == 0 ? false : true;
        }




    }
}
