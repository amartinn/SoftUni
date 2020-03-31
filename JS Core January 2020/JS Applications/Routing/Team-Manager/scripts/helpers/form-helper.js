const extractFormData = (formRef, formConfig) => {
	return formConfig.reduce((acc, inputName) => {
		acc[inputName] = formRef.elements[inputName].value;
		return acc;
	}, {});
};

const fillFormWithData = (formRef, formValue) => {
	if (!formValue) {
		return;
	}
	Object.entries(formValue).map(([ inputName, value ]) => {
		if (!formRef.elements.namedItem(inputName)) {
			return;
		}
		formRef.elements.namedItem(inputName).value = value;
	});
};

const clearForm = (formRef, formConfig, elements) => {
	if (elements) {
		elements.map((key) => {
			formRef.elements.namedItem(key).value = '';
		});
		return;
	}
	formConfig.map((key) => {
		formRef.elements.namedItem(key).value = '';
	});
};

export const createFormEntity = (formRef, formConfig) => {
	const getValue = () => extractFormData(formRef, formConfig);
	const setValue = (formValue) => fillFormWithData(formRef, formValue);
	const clear = (elements) => clearForm(formRef, formConfig, elements);
	return {
		getValue,
		setValue,
		clear
	};
};
