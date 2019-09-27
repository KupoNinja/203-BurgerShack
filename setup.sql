-- CREATE TABLE IF NOT EXISTS burgers (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255),
--     price decimal(3,2) DEFAULT 99,

--     PRIMARY KEY(id)
-- );

-- CREATE TABLE IF NOT EXISTS sides (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255),
--     price decimal(3,2) DEFAULT .99,

--     PRIMARY KEY(id)
-- );

CREATE TABLE IF NOT EXISTS drinks (
    id VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    price decimal(3,2) DEFAULT .99,

    PRIMARY KEY(id)
);

-- INSERT INTO burgers (id, name, description, price) 
-- VALUES ("b-1", "Big Kahuna", "Pineapple Yum", 7.99);

-- INSERT INTO sides (id, name, description, price) 
-- VALUES ("s-1", "Chili Cheese Fries", "It's Chili and Cheesey", 2.33);

-- INSERT INTO drinks (id, name, description, price) 
-- VALUES ("d-1", "Peach Tea", "Get some sun and go to the peach!", 1.99);

-- ALTER TABLE burgers 
--     MODIFY price decimal(3,2);

-- UPDATE burgers SET price = 7.99 WHERE id = "b-1";

-- DELETE FROM burgers WHERE id = "b-1";

SELECT * FROM drinks