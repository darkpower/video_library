CREATE TABLE IF NOT EXISTS User (
       [Id] integer(8) PRIMARY KEY,
       [Username] varchar(20),
       [Password] varchar(20)
);

CREATE TABLE IF NOT EXISTS Company(
       [Id] integer(8) PRIMARY KEY,
       [Name] varchar(255),
       [Http] varchar(255)
);
