type = ['','info','success','warning','danger'];
    	

demo = {
    showNotificationSucess: function (Msg) {
         color = 2;
        
        $.notify({
            icon: "glyphicon glyphicon-ok",
            message: Msg

        }, {
            type: type[color],
            timer: 1000,
            placement: {
                from: 'top',
                align: 'right'
            }
        });
    },

    showNotificationwarning: function (Msg) {
        color = 3;

        $.notify({
            icon: "glyphicon glyphicon-ok",
            message: Msg

        }, {
            type: type[color],
            timer: 1000,
            placement: {
                from: 'top',
                align: 'right'
            }
        });
    },

	showNotificationError: function(Msg){ 
	    color = 4;
	 
    	$.notify({
    	    icon: "glyphicon glyphicon-th-list",
        	message: Msg
        	
        },{
            type: type[color],
            timer: 1000,
            placement: {
                from: 'top',
                align: 'right'
            }
        });
	}

    
}

