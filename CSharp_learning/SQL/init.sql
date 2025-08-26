-- 初始化数据库脚本

-- 创建用户表
CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL
);

-- 创建书籍表
CREATE TABLE Books (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Author VARCHAR(100) NOT NULL,
    ISBN VARCHAR(20) NOT NULL UNIQUE
);

-- 插入基本测试数据
INSERT INTO Users (Username, Password) VALUES ('testuser', 'password123');
INSERT INTO Books (Title, Author, ISBN) VALUES ('C# Programming', 'John Doe', '1234567890');
INSERT INTO Books (Title, Author, ISBN) VALUES ('Learning SQL', 'Jane Smith', '0987654321');