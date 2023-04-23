/* запрос выводит сотрудиков, чье имя начинается на "Р" и заканчивается на "н" */
SELECT * FROM employees
WHERE employees.name LIKE 'Р%н';