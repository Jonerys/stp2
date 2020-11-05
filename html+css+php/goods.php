<!DOCTYPE html>
<html lang="ru">
    <head>
        <meta charset="utf-8" />
        <title>Товары</title>
        <link rel="stylesheet" href="styles.css" />
        <script src="script.js"></script>
		
    </head>
    


    <body>
		<h1>Товары</h1>
		<div id="div_table">
		<?php
			//require("db_get_data.php");
			$db = mysqli_connect('localhost', 'root', '', 'goods') or die();
			mysqli_set_charset($db, 'utf8');
			$data_source = mysqli_query($db, "SELECT * FROM goods_main") or die("Ошибка " . mysqli_error($db));
			$result = mysqli_fetch_all($data_source, MYSQLI_ASSOC);
			echo '<table id="main_table" border="1" width="500px" style="float:left; margin-left:10px;">';
			echo "<tr><th>ИД</th><th>Название</th></tr>";
			for($i = 0; $i < count($result); $i++) {
				echo "<tr>";
					echo "<td>" . $result[$i]["id"] . "</td>";
					echo "<td>" . $result[$i]["name"] . "</td>";
					echo "</tr>";
			}
			echo "</table>";
		?>
			
		
		</div>
		<div style="float: left; display:inline-block; margin-left:15px;">
			<button id="add" onclick="change_visibility('add', 'add_form')">Добавить</button>
			<span id="add_form" >
				<div id="add_f">
					<input id="txt" type="text" width="100px" name="name" />
					<input id="sub" type="submit" value="Подтвердить" onclick="ajax(1, 'txt', null)"/>
					<button id="cancel" onclick="change_visibility('add_form', 'add')">Отмена</button>
				</div>
				
			</span></br>
			<button id="update" onclick="change_visibility('update', 'update_form')">Редактировать</button>
			<span id="update_form">
				<div id="upd_f">
					<select id="sel_upd" name="selector">
						<?php 
							for ($i = 0; $i < count($result); $i++) {
								echo "<option>". $result[$i]["id"] . "</option>";
							}
						?>
					</select>
					<input id="txt2" type="text" width="100px" name="name" />
					<input type="submit" value="Подтвердить" onclick="ajax(2, 'txt2', 'sel_upd')"/>
					<button id="cancel" onclick="change_visibility('update_form', 'update')">Отмена</button>
				</div>
				
				
			</span></br>
			<button id="delete" onclick="change_visibility('delete', 'delete_form')">Удалить</button>
			<span id="delete_form">
				<div id="del_f">
				<select id="sel_del" name="selector2">
                    <?php 
                        for ($i = 0; $i < count($result); $i++) {
							echo "<option>". $result[$i]["id"] . "</option>";
                        }
                    ?>
                </select>
                <input type="submit" value="Подтвердить" onclick="ajax(3, null, 'sel_del')"/>
				<button id="cancel" onclick="change_visibility('delete_form', 'delete')">Отмена</button>
				</div>
                
			</span></br>
		</div>
    </body>
</html>