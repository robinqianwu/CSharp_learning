using Microsoft.AspNetCore.Authentication.JwtBearer;  // JWT认证相关
using Microsoft.IdentityModel.Tokens;                 // Token验证相关
using System.Text;                                    // 文本编码相关
using CSharp_learning.Services;                       // 项目自定义服务

//应用程序构建器创建
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();              // 添加MVC控制器支持
builder.Services.AddEndpointsApiExplorer();     // 添加API浏览器支持
builder.Services.AddSwaggerGen();               // 添加Swagger文档生成
builder.Services.AddScoped<DatabaseService>();   // 注册数据库服务（作用域生命周期）

// Configure JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,              // 验证令牌发行者
            ValidateAudience = true,            // 验证令牌接收者
            ValidateLifetime = true,            // 验证令牌有效期
            ValidateIssuerSigningKey = true,    // 验证签名密钥
            ValidIssuer = builder.Configuration["Jwt:Issuer"],        // 配置发行者
            ValidAudience = builder.Configuration["Jwt:Audience"],     // 配置接收者
            IssuerSigningKey = new SymmetricSecurityKey(              // 配置签名密钥
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? 
                    throw new InvalidOperationException("JWT Key not found")))
        };
    });

// Add CORS （跨域资源共享）配置
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")   // 允许来自Angular开发服务器的请求
                   .AllowAnyHeader()                       // 允许任何请求头
                   .AllowAnyMethod();                       // 允许任何HTTP方法
        });
});

// 应用程序构建
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())    // 如果是开发环境
{
    Console.WriteLine("In Development environment!");
    app.UseSwagger();                   // 启用Swagger
    app.UseSwaggerUI();                 // 启用Swagger UI界面
}

//app.UseHttpsRedirection();              // 启用HTTPS重定向
app.UseCors();                          // 启用CORS中间件
app.UseAuthentication();                // 启用认证中间件
app.UseAuthorization();                 // 启用授权中间件
app.MapControllers();                   // 配置控制器路由映射

app.Run();                              // 运行应用程序
