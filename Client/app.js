(function($){
    function processForm( e ){
        var dict = {
        	Title : this["title"].value,
            Director: this["director"].value,
            Genre: this["Genre"].value
        };

        

        $.ajax({
            url: 'https://localhost:44325/api/movie',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
               
               $('#movieTable').html( data );
              
                
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });
    
    
        $.ajax({

            url: 'https://localhost:44325/api/movie',
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
                // $('#').html( data );

            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
            
        });
        



    $('#my-form').submit( processForm );
}(jQuery);


$(document).ready(function(){
    $.getJSON("https://localhost:44325/api/movie", function(data){
        var movieInfo = ' ';
        $.each(data, function(key, value){
            movieInfo += '<tr>';
            movieInfo += '<td>' +value["title"]+ '</td>'; 
            movieInfo += '<td>' +value["director"]+ '</td>'; 
            movieInfo += '<td>' +value["genre"]+ '</td>';
            movieInfo += '</tr>';
        
    
        });
     
    $('#movieTable').append(movieInfo);
    })});
  
    function validateForm() {
        var valForm = document.forms["my-form"]["title"].value;
            if (valForm == "") {
            alert("Title must be filled out");
        return false;
        }
        
}});


function PUT() {
    $(document).ready(function () {  
        $("#Save").click(function () {  
            $.ajax({  
                url: 'https://localhost:44325/api/movie ? movieId = id ',  
                type: 'PUT',  
                dataType: 'json',  
                data: { "": 'sourav' },  
                success: function (data, textStatus, xhr) {  
                    console.log(data);  
                },  
                error: function (xhr, textStatus, errorThrown) {  
                    console.log('Error in Operation');  
                }  
            });  
        });  
    });  
}


