$(function () {
    
    

     $(".moveButton").click(function () {
        var player_id = $(this).val();
        var player = JSON.parse(player_id);
        $(this).html(player["marker"]);
        var player_move = $(this).attr("position");
        var url = "api/DB/UpdatePlayerMove";
        var game_num = player["num"];
        var player_marker = player["marker"];
        var params = { 'id': game_num, 'player': player_marker, 'move': player_move };
        $.ajax({
            url:url,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(params),
           // data: {'id':game_num,'player':player_marker,'move':player_move},
            success: function (result) {
                if (result == "X" || result == "O") {
                    alert("You Win! Good Job!")
                }
               
            }
        });
    });
});
