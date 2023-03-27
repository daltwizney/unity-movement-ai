mergeInto(LibraryManager.library, {

    SayHello: function() {

        window.HandleHelloMessage();
    },

    SendCustomEventMessage: function(msg) {

        window.HandleCustomEventMessage(UTF8ToString(msg));
    }
})