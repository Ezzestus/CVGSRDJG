CREATE OR REPLACE VIEW Sales_Report AS--
SELECT g.game_name, COUNT(DISTINCT l.game_id) * SUM(l.quantity) AS 'Units Sold', (l.price - g.cost) / g.cost * 100 AS 'Profit Margin', l.price  * SUM(l.quantity) AS 'Sales Volume', ((l.price  - g.cost) / g.cost) * l.price  * SUM(l.quantity)  AS 'Total Profit'
FROM Game g
JOIN Line_Item l
	ON g.game_id = l.game_id
GROUP BY l.game_id;

SELECT * FROM Sales_Report;
