/* запрос выводит отдел с максимальной суммарной заработной платой сотрудников */
SELECT departments.id, departments.name, SUM(employees.salary) AS 'Total Salary' FROM departments
JOIN employees ON employees.department_id = departments.id
GROUP BY departments.id
ORDER BY SUM(employees.salary) DESC
LIMIT 1;