CREATE TABLE Matters (
    id SERIAL PRIMARY KEY,
    reference VARCHAR(50),
    created_at TIMESTAMP
);

CREATE TABLE Orders (
    id SERIAL PRIMARY KEY,
    matter_id INT REFERENCES Matters(id),
    created_at TIMESTAMP
);

CREATE TABLE Certificates (
    id SERIAL PRIMARY KEY,
    order_id INT REFERENCES Orders(id),
    type VARCHAR(20),
    created_at TIMESTAMP
);



INSERT INTO Matters (id, reference, created_at) VALUES
(1, 'M1', NOW() - INTERVAL '40 days'),
(2, 'M2', NOW() - INTERVAL '20 days'),
(3, 'M3', NOW() - INTERVAL '5 days');

INSERT INTO Orders (id, matter_id, created_at) VALUES
(10, 1, NOW() - INTERVAL '39 days'),
(11, 1, NOW() - INTERVAL '15 days'),
(12, 2, NOW() - INTERVAL '18 days'),
(13, 3, NOW() - INTERVAL '4 days');

INSERT INTO Certificates (id, order_id, type, created_at) VALUES
(100, 10, 'Title', NOW() - INTERVAL '35 days'),
(101, 11, 'Plan', NOW() - INTERVAL '10 days'),
(102, 12, 'Title', NOW() - INTERVAL '25 days'),
(103, 12, 'Plan', NOW() - INTERVAL '20 days'),
(104, 13, 'Plan', NOW() - INTERVAL '2 days');



-- Query A
SELECT o.matter_id,
       COUNT(c.id) AS certificates_count
FROM Orders o
JOIN Certificates c ON c.order_id = o.id
WHERE c.created_at >= NOW() - INTERVAL '30 days'
GROUP BY o.matter_id;

-- Query B
SELECT m.id AS matter_id
FROM Matters m
WHERE NOT EXISTS (
    SELECT 1
    FROM Orders o
    JOIN Certificates c ON c.order_id = o.id
    WHERE o.matter_id = m.id
      AND c.type = 'Title'
      AND c.created_at >= NOW() - INTERVAL '30 days'
);

--Index
CREATE INDEX idx_certificates_type_createdat_orderid
ON Certificates (type, created_at, order_id);