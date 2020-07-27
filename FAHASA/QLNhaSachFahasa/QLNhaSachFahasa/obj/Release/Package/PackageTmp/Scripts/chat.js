var chatArea = document.getElementById('chat-area');
var count = 0;
var botCount = 0;
var userCount = 0;
var nextMessage = {
  message: "",
  sender: ""
};
var sendSpecialChat = [false, ""];
var botSilent = false;

var enterListener = window;
var startListener = document.getElementById("startButton");
var sendListener = document.getElementById("sendButton");
var composer = document.getElementById("composer");

if (count == 0) {
  listenFor()
}
function listenFor() {
  console.log("🔈 Starting to listen for Enter Key or Mouse Click.");
  
  enterListener.addEventListener("keydown", listen);
  startListener.addEventListener("click", listen);
  sendListener.addEventListener("click", listen);
}

function listen(e) {
  if (e.keyCode === 13) {
    e.preventDefault();
    if (!e.shiftKey) {
      console.log("⌨ Listen Event: " + e + ", Type: " + e.type + ", Keycode: " + e.keyCode);
      pauseListening();
      lookForChat();
    }
  }
  if (e.type == "click") {
    console.log("🖱 Listen Event: " + e + ", Type: " + e.type + ", Button: " + e.which);
    pauseListening();
    lookForChat(); 
  }
}
                                  
function pauseListening() {
  enterListener.removeEventListener("keydown", listen);
  startListener.removeEventListener("click", listen);
  sendListener.removeEventListener("click", listen);
  console.log("🔇 Stop listening for enter or click.");
}

var botScript = [
    "Xin chào! Bạn cần hỗ trợ gì?",
    "Xin chào! Bạn cần hỗ trợ gì?",
    "Xin chào! Bạn cần hỗ trợ gì?",
    "Tạm biệt bạn. Chúc bạn có một ngày tốt lành"
  ];
  
  // goodbye is a variable that stores what the robot will say when it runs out of other things to say.
  var goodbye = "Goodbye! I have to go now.";


  function lookForChat() {
      // If there have been no chats yet, start the bot.
      debugger;
    if (count == 0) {
      startBot();
    }
    
    console.log("🌀 Looking for chat " + (count + 1));
    
    // check who sent the last chat
    last = nextMessage.sender; 
    
    if (last == "bot") {
      // if the bot chatted last wait for the user to send a chat
      userChat();
      
    } else {
      // Send the cursor to the compose text area.
      composer.focus();
      
      // If botSilent is true the bot is done chatting
      // Set nextMessage.sender to "bot" to make the user chat next
      // Run listenFor() to wait for the user to chat.
      if (botSilent) {
        nextMessage.sender = "bot";
        nextMessage.message = "";
        listenFor();
        
      } else {
        
        // If the user chatted last or the chat just started have the bot send a chat.
        // Set the appropriate wait time to make the bot feel realistic.
        // Then run the botChat function which will find the right message for the bot
        if (count == 0) {
          wait = 100;
        } else {
          wait = 500;
        }
        setTimeout(function(){
          console.log("🕙 Waiting for bot");
          botChat();
        }, wait);
      }
    }
  }
  
  
  // startBot is a function that starts the bot for the first time. It clears away the start button from the HTML.
  function startBot(){
    console.log("🤖 Starting bot . . .");
    chatArea.innerHTML = '';
    document.getElementById('compose-area').style.display = 'block';
  }

  function botChat() {
    // Set the bot as the sender of the next message.
    nextMessage.sender = "bot";
  
    if (botCount >= botScript.length) {
      nextMessage.message = goodbye
      botSilent = true;
    } else {
      // Set the bot's next message as the next string in the botScript array.
      nextMessage.message = botScript[botCount];
    }
  
    // Check sendSpecialChat to see if anything special should happen.
    if (sendSpecialChat[0]) {
      nextMessage.message = sendSpecialChat[1]; 
    }
  
    // Send the bot's message.
    send(nextMessage.sender, nextMessage.message);
  
    // Count 1 more chat that the bot has sent unless the chat was a sendSpecialChat.
    if (sendSpecialChat[0]) {
      sendSpecialChat = [false, ""];
  
    } else {
      botCount += 1;
    }
  
    // Start listening again after the bot has sent a message.
    listenFor();
  }

  


function userChat() {
    debugger;
    // Find where the user is inputing text.
    compose_area = document.getElementById('composer');
  
    // Set the user as the sender of the next message.
    nextMessage.sender = "user";
  
    // Get the user's input in the compose_area and clear the compose_area.
    nextMessage.message = compose_area.value;
    compose_area.value = "";
    
    
    // We need to convert the user's message to upper case to check if it matches with any prompts using the .toUpperCase() function.
    
    uppercase = nextMessage.message.toUpperCase();
  
    // We can test if the user's message matches any of the prompts using if statements.
    console.log("✍ Code for custom prompts goes here");
    
    if (uppercase == "HI" || uppercase == "HELLO" || uppercase == "XIN CHÀO" || uppercase == "XIN CHAO" || uppercase == "CHAO" || uppercase == "CHÀO") {
        sendSpecialChat = [true, "Xin chào, rất vui được gặp bạn! Bạn cần hỗ trợ gì?"];
    }
    if (uppercase == "NGOC PHUC" || uppercase == "NGỌC PHÚC") {
        sendSpecialChat = [true, "Chào Admin page Ngọc Phúc style"];
    }
    if (uppercase == "NGỌC HUY" || uppercase == "NGOC HUY") {
        sendSpecialChat = [true, "Xin chào! Admin page Dương Ngọc Huy"];
    }
    if (uppercase == "CC") {
        sendSpecialChat = [true, "Bạn hãy lịch sự!"];
    }
    if (/SDT/.test(uppercase) || /PHONE/.test(uppercase) || /MOBILE/.test(uppercase)) {
        sendSpecialChat = [true, "Bạn có thể liên hệ trực tiếp với Admin qua số điện thoại 035033933."];
    }
    if (/EMAIL/.test(uppercase)) {
        sendSpecialChat = [true, "Bạn có thể liên hệ trực tiếp với Admin qua duongngochuy.hufi@gmail.com"];
    }
    // sendSpecialChat is an array that will override the next thing the bot says with the second value if the first value is true. If the first value is false the bot will say the next thing in the script.
  
  
    // Send user's message.
    send(nextMessage.sender, nextMessage.message);
  
    // Count 1 more chat that the user has sent.
    userCount += 1;
  
    // Ask the bot for another chat.
    lookForChat()
  
  }


  function send(sender, message) {
    console.log("🗨 " + sender + ": " + message);
  
    // Insert the nextMessage into the HTML.
    chatArea.insertAdjacentHTML("beforeend", "<div id='chat-" + count + "' class='chat-container'><div class='chat-wrapper' id='chat-a-" + count + "'><p id='a-' class='chat-" + sender + "'>" + message + "</p><div class='avatar avatar-" + sender + "'></div></div></div>");
  
    // Scroll the most recent message onto the screen.
    document.getElementById('chat-' + count).scrollIntoView();
  
    // Count one more message that has been sent.
    count += 1;
}