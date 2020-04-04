import { applyCommon } from './common.js';

export async function homeHandler() {
	await applyCommon.call(this);
	await this.partial('../../templates/home/home.hbs');
}
