# change previous Windows Form application to Backend project in order to work with new added Angular frontend at 2025.08.27
现在我们已经成功地：

删除了Windows Forms相关的代码
增强了BookController的功能
扩展了DatabaseService的功能，添加了CRUD操作
所有功能现在都通过REST API提供，可以被Angular前端调用。API端点包括：

GET /api/book - 获取所有图书
GET /api/book/{id} - 获取特定图书
GET /api/book/available - 获取所有可借阅的图书
POST /api/book - 创建新图书
PUT /api/book/{id} - 更新图书
DELETE /api/book/{id} - 删除图书

可以使用Postman或其他工具发送POST请求到 http://localhost:5000/api/auth/login 来测试登录功能。请求体应该是：

{
    "username": "yourUsername",
    "password": "yourPassword"
}

API服务器已经启动并在运行。让我们在新的终端中测试登录API：
可参看loginTestSuccessful.png

在启动Development Profile运行时，可以启动SwaggerUI来检查API支持的Url
http://localhost:5000/swagger
从而替代postman，需要关闭httpsRedirection和CORS

2025.09.29:
- add a dummy windows project, HelloWorld project into current web project CSharp_learning
    -- they are isolated with each, can be build and run separately
        --- 'dotnet build' in CSharp_learning will build both
        --- 'dotnet run' in different folder will start the differetn project, or can use 'dotnet run --project .\DummyProject\HelloWorld.csproj' to start the desired project.