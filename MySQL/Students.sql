Drop TABLE IF EXISTS Students;

CREATE TABLE Students
(
  student_id INT PRIMARY KEY,
  student_name VARCHAR(50) NOT NULL,
  grade INT NOT NULL
);

INSERT INTO Students (student_id, student_name, grade) VALUES
(1,'Alice', 89),
(2,'Bob', 100),
(3,'Charlie', 92),
(5,'Luice', 50);

SELECT * FROM Students WHERE grade BETWEEN 90 AND 100 ORDER BY grade DESC;

