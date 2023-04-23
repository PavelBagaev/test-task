# test-task

В файлах под цифрами 1-4 содержатся SQL queries, пронумерованные в соответствии с заданием. 

Таблицы в БД имеют следующий вид:

CREATE TABLE departments (
	id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(100),
    PRIMARY KEY(id)
);

CREATE TABLE employees (
	id INT NOT NULL AUTO_INCREMENT,
	department_id INT NOT NULL,
    chef_id INT,
    name VARCHAR(100),
    salary INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (department_id) REFERENCES departments(id),
    FOREIGN KEY (chef_id) REFERENCES employees(id)
);

В файле UniqueWords.cs содержится программа из второго задания. 
