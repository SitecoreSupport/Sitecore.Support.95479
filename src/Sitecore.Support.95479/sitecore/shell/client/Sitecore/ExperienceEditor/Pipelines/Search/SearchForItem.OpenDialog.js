define(["sitecore", "/-/speak/v1/ExperienceEditor/ExperienceEditor.js"], function (Sitecore, ExperienceEditor) {
    return ExperienceEditor.PipelinesUtil.generateDialogCallProcessor({
        url: function (context) { return context.currentContext.value; },
        features: "dialogHeight: 700px;dialogWidth: 1300px;",
        onSuccess: function (context, itemId) {
            // Sitecore.Support.95479
			// context.currentContext.value = itemId;
            context.currentContext.value = itemId.split('/')[0];
            context.currentContext.argument = context.currentContext.language;
            context.currentContext.language = itemId.split('/').pop();
        }
    });
});