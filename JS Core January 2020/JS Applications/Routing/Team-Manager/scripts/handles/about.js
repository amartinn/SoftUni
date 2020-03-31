import { applyCommon } from './common.js';

export async function aboutHandler() {
	await applyCommon.call(this);
	await this.partial('../../templates/about/about.hbs');
}
