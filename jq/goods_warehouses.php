<!DOCTYPE html>
<html lang="ru">
    <head>
        <meta charset="utf-8" />
        <title>Товары на складах</title>
        <link rel="stylesheet" href="styles.css" />
        <script src="script_gw.js"></script>
        <script src="jquery-3.5.1.min.js"></script>
        <script type="text/javascript">
        
            $(document).ready(function() {
                $('#add').click(function(){
                    refresSelAJAX("selGd_add");
                    refresSelAJAX("selWh_add");
                    changeVisibility('add', 'add_form');
                });
                $('#update').click(function(){
                    refresSelAJAX("selGd_upd");
                    refresSelAJAX("selWh_upd");
                    //$('#sel_upd').trigger('change');
                    changeVisibility('update', 'update_form');
                    
                });
                $('#sel_upd').change(function() {
                    let table = document.getElementById("main_table");
                    let index = 0;
                    let id = $('#sel_upd option:selected').text();
                    for (let i = 0; i < table.rows.length; i++) {
                        if (table.rows[i].cells[0].innerHTML == id) { 
                            index = i;
                            break;
                        }
                    }
                    let gname = table.rows[index].cells[1].innerHTML;
                    let wname = table.rows[index].cells[2].innerHTML;
                    let selG = document.getElementById("selGd_upd");
                    let selW = document.getElementById("selWh_upd");
                    for (let i = 0; i < selG.options.length; i++) {
                        if (selG.options[i].innerHTML == gname) {
                            selG.selectedIndex = i;
                            break;
                        }
                    }
                    for (let i = 0; i < selW.options.length; i++) {
                        if (selW.options[i].innerHTML == wname) {
                            selW.selectedIndex = i;
                            break;
                        }
                    }
                });
                $('#sub_i').click(function(){
                    ajax("1");
                });
                $('#sub_u').click(function(){
                    ajax("2");
                });
                $('#sub_d').click(function(){
                    ajax("3");
                    $('#sel_del').selectedIndex = 0;
                });
            });
        </script>
    </head>

    <body>
        <div>
            <h1>Товары на складах</h1>
            <div id="div_table">
                <?php
                    $db = mysqli_connect('localhost', 'root', '', 'goods') or die();
                    mysqli_set_charset($db, 'utf8');
                    $dataSource = mysqli_query($db, "SELECT goodswh.id, goods_main.name gn, warehouses.name wn FROM goodswh, goods_main, warehouses WHERE goodswh.id_gd = goods_main.id AND goodswh.id_wh = warehouses.id ORDER BY id ASC") 
                        or die("Ошибка " . mysqli_error($db));
                    $result = mysqli_fetch_all($dataSource, MYSQLI_ASSOC);
                    echo '<table id="main_table" border="1" width="500px" style="float:left; margin-left:10px;">';
                    echo "<tr><th>ИД</th><th>Товар</th><th>Склад</th></tr>";
                    for($i = 0; $i < count($result); $i++) {
                        echo "<tr>";
                            echo "<td>" . $result[$i]["id"] . "</td>";
                            echo "<td>" . $result[$i]["gn"] . "</td>";
                            echo "<td>" . $result[$i]["wn"] . "</td>";
                            echo "</tr>";
                    }
                    echo "</table>";
                ?>
            </div>
            <div style="float: left; display:inline-block; margin-left:15px;">
                <div id="div_add">
                    <button id="add" onclick="changeVisibility('add', 'add_form')">Добавить</button>
                    <span id="add_form" >
                        <select id="selGd_add" name="selector">
                        </select>
                        <select id="selWh_add" name="selector">
                        </select>    
                        <input id="sub_i" type="submit" value="ОК"/>
                        <button id="cancel" onclick="changeVisibility('add_form', 'add')">Отмена</button>
                    </span></br>
                </div>
                <div id="div_upd">
                   <button id="update">Редактировать</button>
                    <span id="update_form">
                        <select id="sel_upd" name="selector">
                            <?php 
                                for ($i = 0; $i < count($result); $i++) {
                                    echo "<option>". $result[$i]["id"] . "</option>";
                                }
                            ?>
                        </select>
                        <select id="selGd_upd" name="selector">
                        </select>
                        <select id="selWh_upd" name="selector">
                        </select>    
                        <input id="sub_u" type="submit" value="ОК"/>
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
                        <input id="sub_d" type="submit" value="ОК"/>
                        <button id="cancel" onclick="changeVisibility('delete_form', 'delete')">Отмена</button>
                    </span></br>
                </div>
            </div>    
        </div>
    </body>
</html>