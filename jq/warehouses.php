<!DOCTYPE html>
<html lang="ru">
    <head>
        <meta charset="utf-8" />
        <title>Склады</title>
        <link rel="stylesheet" href="styles.css" />
        <script src="script.js"></script>
        <script src="jquery-3.5.1.min.js"></script>
        <script type="text/javascript">
            function reset(mode){
                switch (mode) {
                    case 1:
                        $('#txt').val('');
                        break;
                    case 2:
                        $('#sel_upd')[0].selectedIndex = 0;
                        $('#txt2').val('');
                        break;
                    case 3:
                        $('#sel_del')[0].selectedIndex = 0;
                        break;
                }
            }
        
            $(document).ready(function() {
                $('#sub_i').click(function(){
                    ajax("1", "db_files/db_warehouses.php");
                    reset(1);
                });
                $('#sub_u').click(function(){
                    ajax("2", "db_files/db_warehouses.php");
                    reset(2);
                });
                $('#sub_d').click(function(){
                    ajax("3", "db_files/db_warehouses.php");
                    reset(3);
                });
            });
        </script>
    </head>

    <body>
        <div>
            <h1>Склады</h1>
            <div id="div_table">
                <?php
                    $db = mysqli_connect('localhost', 'root', '', 'goods') or die();
                    mysqli_set_charset($db, 'utf8');
                    $dataSource = mysqli_query($db, "SELECT * FROM warehouses ORDER BY id ASC") or die("Ошибка " . mysqli_error($db));
                    $result = mysqli_fetch_all($dataSource, MYSQLI_ASSOC);
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
                <div id="div_add">
                    <button id="add" onclick="changeVisibility('add', 'add_form')">Добавить</button>
                    <span id="add_form" >
                        <input id="txt" type="text" width="100px" name="name" />
                        <input id="sub_i" type="submit" value="Подтвердить"/>
                        <button id="cancel" onclick="changeVisibility('add_form', 'add')">Отмена</button>
                    </span></br>
                </div>
                <div id="div_upd">
                   <button id="update" onclick="changeVisibility('update', 'update_form')">Редактировать</button>
                    <span id="update_form">
                        <select id="sel_upd" name="selector">
                            <?php 
                                for ($i = 0; $i < count($result); $i++) {
                                    echo "<option>". $result[$i]["id"] . "</option>";
                                }
                            ?>
                        </select>
                        <input id="txt2" type="text" width="100px" name="name" />
                        <input id="sub_u" type="submit" value="Подтвердить"/>
                        <button id="cancel" onclick="changeVisibility('update_form', 'update')">Отмена</button>
                    </span></br>
                </div>
                <div id="div_del">
                    <button id="delete" onclick="changeVisibility('delete', 'delete_form')">Удалить</button>
                    <span id="delete_form">
                        <select id="sel_del" name="selector2">
                            <?php 
                                for ($i = 0; $i < count($result); $i++) {
                                    echo "<option>". $result[$i]["id"] . "</option>";
                                }
                            ?>
                        </select>
                        <input id="sub_d" type="submit" value="Подтвердить"/>
                        <button id="cancel" onclick="changeVisibility('delete_form', 'delete')">Отмена</button>
                    </span></br>
                </div>
            </div>    
        </div>
    </body>
</html>