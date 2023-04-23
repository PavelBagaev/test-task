/* запрос выводит максимальную длину цепочки руководителей по таблице сотрудиков (вычисляет глубину дерева) */
WITH RECURSIVE employees_depth(id, depth) AS (
  SELECT employees.id, 0 FROM employees WHERE employees.chef_id IS NULL
  UNION ALL
  SELECT employees.id, employees_depth.depth + 1 FROM employees_depth
  JOIN employees ON employees.chef_id = employees_depth.id
)
SELECT MAX(depth) FROM employees_depth;