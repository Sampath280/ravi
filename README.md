"# ravi" 
```js
const express = require('express');
const cors = require('cors');
const { WebPubSubServiceClient } = require('@azure/web-pubsub');
const { WebPubSubEventHandler } = require('@azure/web-pubsub-express');

const hubname = "Hub";
const connectionString = "WebPubSubServiceconnectionString";
const service = new WebPubSubServiceClient(connectionString, hubname);

const port = 8080;
const app = express();
s
app.use(cors()); 

app.use(express.static("build"));

app.get('/negotiate', async (req, res) => {
  try {
    const token = await service.getClientAccessToken({
      roles: [
        "webpubsub.sendToGroup.chat",
        "webpubsub.joinLeaveGroup.chat"
      ]
    });
    res.status(200).send(token.url);
  } catch (error) {
    console.error("Error during negotiation:", error);
    res.status(500).send("Failed to negotiate connection.");
  }
});

 let handler = new WebPubSubEventHandler(hubname, {
  path: '/eventhandler',
  handleUserEvent: async (req, res) => {
     res.success();
  }
 });

 app.use(handler.getMiddleware());

app.listen(port, () => console.log(`Open http://localhost:${port}`));

```
