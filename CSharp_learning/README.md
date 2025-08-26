# CSharp_learning 项目

该项目是一个图书管理登录系统，旨在展示面向对象编程的基本概念。项目包含以下主要功能：

- 用户登录界面，允许用户输入用户名和密码进行身份验证。
- 连接到 MySQL 数据库，存储用户和书籍信息。
- 提供书籍管理功能，包括添加、删除和查看书籍。

## 文件结构

```
CSharp_learning
├── src
│   ├── Program.cs          // 应用程序入口点
│   ├── Models
│   │   ├── User.cs         // 用户模型
│   │   └── Book.cs         // 书籍模型
│   ├── Forms
│   │   ├── LoginForm.cs    // 登录界面
│   │   └── MainForm.cs     // 主界面
│   ├── Services
│   │   ├── DatabaseService.cs // 数据库服务
│   │   ├── AuthenticationService.cs // 身份验证服务
│   │   └── BookService.cs   // 书籍服务
│   └── Data
│       └── DatabaseContext.cs // 数据库上下文
├── SQL
│   └── init.sql            // 初始化数据库的SQL脚本
├── App.config              // 应用程序配置文件
├── packages.config         // NuGet包配置
├── CSharp_learning.csproj  // 项目文件
└── README.md               // 项目文档
```

## 使用说明

1. 确保已安装 MySQL 数据库，并创建相应的数据库。
2. 修改 `App.config` 中的数据库连接字符串以匹配您的数据库设置。
3. 运行 `src/Program.cs` 启动应用程序。
4. 使用提供的用户名和密码进行登录，访问书籍管理功能。

## 贡献

欢迎对该项目提出建议和贡献代码！请遵循项目的代码风格和结构。