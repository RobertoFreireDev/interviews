SELECT
	employee_id as 'Id',
	CONCAT(first_name,' ',last_name) as 'Employee',
	manager_id as 'Manager Id'
FROM employees
ORDER BY manager_id

SELECT
	E2.employee_id as 'Manager Id',
	CONCAT(E2.first_name,' ',E2.last_name) as 'Manager',
	E1.employee_id as 'Employee Id',
	CONCAT(E1.first_name,' ',E1.last_name) as 'Employee'
FROM employees E1
JOIN employees E2 ON E1.manager_id = E2.employee_id
ORDER BY E2.employee_id
