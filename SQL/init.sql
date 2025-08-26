CREATE DATABASE IF NOT EXISTS library_db;
USE library_db;

CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    role VARCHAR(20) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS books (
    id INT AUTO_INCREMENT PRIMARY KEY,
    isbn VARCHAR(13) NOT NULL UNIQUE,
    title VARCHAR(200) NOT NULL,
    author VARCHAR(100) NOT NULL,
    publisher VARCHAR(100) NOT NULL,
    publish_date DATE NOT NULL,
    quantity INT NOT NULL DEFAULT 0,
    is_available BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 插入测试数据
INSERT INTO users (username, password, role) VALUES
('admin', 'admin123', 'admin'),
('user1', 'password123', 'user');

INSERT INTO books (isbn, title, author, publisher, publish_date, quantity, is_available) VALUES
('9787111213826', 'C# 编程基础', '张三', '清华大学出版社', '2023-01-01', 5, true),
('9787302147556', '数据结构与算法', '李四', '北京大学出版社', '2023-02-01', 3, true),
('9787115437303', '深入理解计算机系统', '王五', '人民邮电出版社', '2023-03-01', 2, true);
