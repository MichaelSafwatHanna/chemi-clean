const express = require("express");
const fse = require("fs-extra");
const path = require("path");
const bodyParser = require("body-parser");

// Constants
const PORT = 8080;
const HOST = "0.0.0.0";
const repoDir = "/var/www/repos/";
const extension = ".pdf";

// App
const app = express();
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.raw({ limit: '1gb', type: 'application/pdf' }));

app.post("/products/:product", (req, res) => {
  var fileName = req.params.product;
  if (!fileName) {
    res.send("No File Name Provided!");
  }
  var fileContent = req.body;
  var filePath = path.resolve(__dirname, repoDir, fileName).concat(extension);

  fse.ensureDir(path.resolve(__dirname, repoDir)).then(function () {
    fse.writeFile(filePath, fileContent, function (err) {
      if (err) throw err;
      res.send("File Saved!");
    });
  });
});

app.get("/products/:product", (req, res) => {
  var fileName = req.params.product;
  if (!fileName) {
    res.send("No File Name Provided!");
  }
  var filePath = path.resolve(__dirname, repoDir, fileName).concat(extension);

  fse.ensureDir(path.resolve(__dirname, repoDir)).then(function () {
    res.sendFile(filePath);
  });
});

app.listen(PORT, HOST);
console.log(`Running on http://${HOST}:${PORT}`);
