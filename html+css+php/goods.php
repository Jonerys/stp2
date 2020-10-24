<!DOCTYPE html>
<html lang="ru">
    <head>
        <meta charset="utf-8" />
        <title>Товары</title>
        <link rel="stylesheet" href="styles.css" />
        <script src="script.js"></script>
    </head>
    
<?php
	$db = mysqli_connect('localhost', 'root', '', 'goods') or die();
    mysqli_set_charset($db, 'utf8');
	
	if (isset($_POST['name']) && !isset($_POST['selector'])) {
		$name = htmlentities(mysqli_real_escape_string($db, $_POST['name']));
		$query ="INSERT INTO goods_main VALUES(NULL, '$name')";
		$result = mysqli_query($db, $query) or die(); 
		header('Location: goods.php');
	}
	if(isset($_POST['name']) && isset($_POST['selector'])){
		$sel_id = htmlentities(mysqli_real_escape_string($db, $_POST['selector']));
		$name = htmlentities(mysqli_real_escape_string($db, $_POST['name']));
		$query ="UPDATE goods_main SET name='$name' where id='$sel_id'";
		$result = mysqli_query($db, $query) or die(); 
		header('Location: goods.php');
	}
	if (isset($_POST['selector2'])){
		$sel_id = htmlentities(mysqli_real_escape_string($db, $_POST['selector2']));
		$query ="DELETE FROM goods_main WHERE id = '$sel_id'";
		$result = mysqli_query($db, $query) or die();
		header('Location: goods.php');
	}
	echo "<h1>Товары</h1>";
	$query ="SELECT * FROM goods_main";
	$result = mysqli_query($db, $query) or die("Ошибка " . mysqli_error($db)); 
	if($result) {
		$rows = mysqli_num_rows($result); // количество полученных строк
		echo "<table border='1' width='500px' style='float:left; margin-left:10px;'><tr><th>ИД</th><th>Название</th></tr>";
		for ($i = 0 ; $i < $rows ; $i++)
		{
			$row = mysqli_fetch_row($result);
			echo "<tr>";
				for ($j = 0 ; $j < 2 ; ++$j) echo "<td>$row[$j]</td>";
			echo "</tr>";
		}
		echo "</table>";
		mysqli_free_result($result);
	}
	$ids_query = mysqli_query($db, "SELECT id FROM goods_main");
	$ids = mysqli_fetch_all($ids_query, MYSQLI_ASSOC);
	mysqli_close($db);
?>

    <body>
		
		<div style="float: left; display:inline-block; margin-left:15px;">
			<button id="add" onclick="change_visibility('add', 'add_form')">Добавить</button>
			<span id="add_form">
				<form method="POST">
					<input id="txt" type="text" width="100px" name="name" />
					<input type="submit" value="Подтвердить"/>
				</form>
				<button id="cancel" onclick="change_visibility('add_form', 'add')">Отмена</button>
			</span></br>
			<button id="update" onclick="change_visibility('update', 'update_form')">Редактировать</button>
			<span id="update_form">
				<form id="upd_f" method="POST">
					<select id="sel_upd" name="selector">
						<?php 
							for ($i = 0; $i < count($ids); $i++) {
								echo "<option>". $ids[$i]["id"] . "</option>";
							}
						?>
					</select>
					<input id="txt2" type="text" width="100px" name="name" />
					<input type="submit" value="Подтвердить"/>
				</form>
				<button id="cancel" onclick="change_visibility('update_form', 'update')">Отмена</button>
				
			</span></br>
			<button id="delete" onclick="change_visibility('delete', 'delete_form')">Удалить</button>
			<span id="delete_form">
				<form id="del_f" method="POST">
				<select id="sel_del" name="selector2">
                    <?php 
                        for ($i = 0; $i < count($ids); $i++) {
							echo "<option>". $ids[$i]["id"] . "</option>";
                        }
                    ?>
                </select>
                <input type="submit" value="Подтвердить"/>
				</form>
                <button id="cancel" onclick="change_visibility('delete_form', 'delete')">Отмена</button>
			</span></br>
		</div>
    </body>
</html>